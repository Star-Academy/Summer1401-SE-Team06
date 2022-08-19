using Repository;

namespace project;

public class ProgramRunner
{
    public void Run()
    {
        var fileReader = new FileReader();
        var studentsData = fileReader.ReadFileFromDisk(@"studentsData.json");
        var scoresData = fileReader.ReadFileFromDisk(@"scoresData.json");

        var dataParser = new JsonParser();
        var students = dataParser.Parse<List<Student>>(studentsData);
        var lessons = dataParser.Parse<List<StudentGrade>>(scoresData);

        DBRepository.Instance.AddStudentsToDB(students);
        DBRepository.Instance.AddGradesToDB(lessons);

        DBRepository.Instance.InitAverageGrade();

        var topStudents = DBRepository.Instance.GetTopNStudents(3);
        
        var output = new OutputPrinter();
        output.PrintTopStudents(topStudents);
    }
}