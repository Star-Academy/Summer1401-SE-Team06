namespace project;

public class Output
{
    public void printTopStudents(List<Student> students)
    {
        for (int i = 0; i < 3; i++)
        {
            var sortedStudents = students.OrderByDescending(x => x.AverageGrade);
            Student student = sortedStudents.ElementAt(i);
            string name = student.FirstName + " " + student.LastName;
            double averageScore = student.AverageGrade;

            Console.WriteLine("Name: " + name + " | Average Score: " + averageScore);
            Console.WriteLine();
        }
    }
}