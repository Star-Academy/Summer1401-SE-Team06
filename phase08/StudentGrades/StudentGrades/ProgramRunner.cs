using DefaultNamespace;

namespace project;

public class ProgramRunner
{
    public void Run()
    {
        var fileReader = new FileReader();
        var output = new OutputPrinter();
        var dbController = DBController.Instance;
        var dataParser = new JsonParser();

        var studentsData = fileReader.ReadFileFromDisk(@"studentsData.json");
        var scoresData = fileReader.ReadFileFromDisk(@"scoresData.json");

        var students = dataParser.Parse<List<Student>>(studentsData);
        var lessons = dataParser.Parse<List<StudentGrade>>(scoresData);

        dbController.AddStudentsToDB(students);
        dbController.AddGradesToDB(lessons);
        
        dbController.InitAverageGrade();

        var topStudents = dbController.GetTopNStudents(3);
        output.PrintTopStudents(topStudents);
    }
}