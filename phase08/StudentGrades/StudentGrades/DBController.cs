using project;

namespace DefaultNamespace;

public class DBController
{
    private static DBController instance;

    private DBController()
    {
    }

    public static DBController Instance
    {
        get
        {
            if (instance == null) instance = new DBController();
            return instance;
        }
    }

    public void InitAverageGrade()
    {
        using (var schoolContext = new SchoolDBContext())
        {
            foreach (var student in schoolContext.Students.ToList())
            {
                var studentAverage = schoolContext.StudentGrades.Where(x => x.StudentNumber == student.StudentNumber)
                    .Average(x => x.Score);
                student.AverageGrade = studentAverage;
                schoolContext.Update(student);
                schoolContext.SaveChanges();
            }
        }
    }

    public void AddStudentsToDB(List<Student> record)
    {
        using (var schoolContext = new SchoolDBContext())
        {
            schoolContext.Students.AddRange(record);
            schoolContext.SaveChanges();
        }
    }
    
    public void AddGradesToDB(List<StudentGrade> record)
    {
        using (var schoolContext = new SchoolDBContext())
        {
            schoolContext.StudentGrades.AddRange(record);
            schoolContext.SaveChanges();
        }
    }

    public List<Student> GetTopNStudents(int n)
    {
        using (var schoolContext = new SchoolDBContext())
        {
            return schoolContext.Students.OrderByDescending(x => x.AverageGrade).Take(n).ToList();
        }
    }
}