using System.Diagnostics;

namespace project;

public class ProgramRunner
{
    public void Run()
    {
        
        var fileReader = new FileReader();
        var output = new OutputPrinter();
        var students = new List<Student>();
            
        string stdPath = AppDomain.CurrentDomain.BaseDirectory + @"studentsData.json";
        string scrPath = AppDomain.CurrentDomain.BaseDirectory + @"scoresData.json";
        var studentsData = fileReader.ReadFileFromDisk(stdPath);
        var scoresData = fileReader.ReadFileFromDisk(scrPath);
        var jsonParser = new JsonParser();
        students = jsonParser.ParseStudents(studentsData);
        students = jsonParser.ParseScores(students, scoresData);
        output.PrintTopStudents(students);
    }
}