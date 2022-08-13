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

    public void AddRecordsToDB(List<Student> students, List<StudentGrade> lessons)
    {
        using (var schoolContext = new SchoolDBContext())
        {
            schoolContext.Students.AddRange(students);
            schoolContext.StudentGrades.AddRange(lessons);
            schoolContext.SaveChanges();
        }
    }
}