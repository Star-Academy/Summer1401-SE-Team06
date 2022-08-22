using project;

namespace Repository;

public class DBRepository
{
    private static SchoolDBContext _schoolContext;
    private static DBRepository instance;

    private DBRepository()
    {
        _schoolContext = new SchoolDBContext();
    }

    public static DBRepository Instance
    {
        get
        {
            if (instance == null) instance = new DBRepository();
            return instance;
        }
    }

    public void InitAverageGrade()
    {
        using (_schoolContext)
        {
            foreach (var student in _schoolContext.Students.ToList())
            {
                var studentAverage = _schoolContext.StudentGrades.Where(x => x.StudentNumber == student.StudentNumber)
                    .Average(x => x.Score);
                student.AverageGrade = studentAverage;
                _schoolContext.Update(student);
                _schoolContext.SaveChanges();
            }
        }
    }

    public void AddStudentsToDB(List<Student> record)
    {
        using (_schoolContext)
        {
            _schoolContext.Students.AddRange(record);
            _schoolContext.SaveChanges();
        }
    }

    public void AddGradesToDB(List<StudentGrade> record)
    {
        using (_schoolContext)
        {
            _schoolContext.StudentGrades.AddRange(record);
            _schoolContext.SaveChanges();
        }
    }

    public List<Student> GetTopNStudents(int n)
    {
        using (_schoolContext)
        {
            return _schoolContext.Students.OrderByDescending(x => x.AverageGrade).Take(n).ToList();
        }
    }
}