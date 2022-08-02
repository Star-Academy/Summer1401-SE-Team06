namespace project;

public class ProgramRunner
{
    public void Run()
    {
        var fileReader = new FileReader();
        var output = new OutputPrinter();
        var students = new List<Student>();
        
        string stdPath = @"C:\Users\User\Summer1401-SE-Team06\Phase03\studentsData.json";
        string scrPath = @"C:\Users\User\Summer1401-SE-Team06\Phase03\scoresData.json";
        var studentsData = fileReader.ReadFileFromDisk(stdPath);
        var scoresData = fileReader.ReadFileFromDisk(scrPath);
        var jsonParser = new JsonParser();
        students = jsonParser.ParseStudents(studentsData);
        students = jsonParser.ParseScores(students, scoresData);
        output.PrintTopStudents(students);
    }
}