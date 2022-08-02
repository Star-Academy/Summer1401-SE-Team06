namespace project;

public class OutputPrinter
{
    public void PrintTopStudents(List<Student> students)
    {
        students.OrderByDescending(x => x.AverageGrade).Take(3).ToList().ForEach(student => Console.WriteLine
                ("Name: " + student.FirstName + " " + student.LastName + " | Average Score: " + student.AverageGrade));
    }
}