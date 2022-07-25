namespace project;

public class Output
{
    public void printTopStudents(List<Student> students)
    {
        for (var i = 0; i < 3; i++)
        {
            var sortedStudents = students.OrderByDescending(x => x.AverageGrade);
            var student = sortedStudents.ElementAt(i);
            var name = student.FirstName + " " + student.LastName;
            var averageScore = student.AverageGrade;
            var rank = i + 1;
            Console.WriteLine("Rank " + rank + ": <<" + "Name: " + name + " | Average Score: " + averageScore + ">>");
            Console.WriteLine();
        }
    }
}