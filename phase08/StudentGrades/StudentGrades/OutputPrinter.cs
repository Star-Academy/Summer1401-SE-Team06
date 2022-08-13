namespace project;

public class OutputPrinter
{
    public void PrintTopStudents(List<Student> toPrint)
    {
        toPrint.ForEach(student =>
            Console.WriteLine
                ($"Name: {student.FirstName} {student.LastName} | Average Score: {student.AverageGrade}"));
    }
}