using DefaultNamespace;

namespace project;

public class ProgramRunner
{
    public void Run()
    {
        var fileReader = new FileReader();
        var output = new OutputPrinter();
        var students = new List<Student>();
        var lessons = new List<StudentGrade>();
        var dbController = DBController.Instance;
        var jsonParser = new JsonParser();

        var studentsData = fileReader.ReadFileFromDisk(@"studentsData.json");
        var scoresData = fileReader.ReadFileFromDisk(@"scoresData.json");

        students = jsonParser.ParseStudents(studentsData);
        lessons = jsonParser.ParseScores(scoresData);

        dbController.AddRecordsToDB(students, lessons);
        dbController.InitAverageGrade();

        output.PrintTopStudents(students);
    }
}