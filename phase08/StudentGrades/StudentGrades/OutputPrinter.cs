using DefaultNamespace;

namespace project;

public class OutputPrinter
{
    public void PrintTopStudents(List<Student> students)
    {
        using (var schoolContext = new SchoolDBContext())
        {
            schoolContext.Students.OrderByDescending(x => x.AverageGrade).Take(3).ToList().ForEach(student =>
                Console.WriteLine
                    ($"Name: {student.FirstName} {student.LastName} | Average Score: {student.AverageGrade}"));
        }
    }
}