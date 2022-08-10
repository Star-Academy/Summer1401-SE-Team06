namespace project;

public class ProgramRunner
{
    public void Run()
    {
        var fileReader = new FileReader();
        var output = new OutputPrinter();
        var students = new List<Student>();
        var lessons = new List<Lesson>();

        var stdPath = @"studentsData.json";
        var scrPath = @"scoresData.json";
        var studentsData = fileReader.ReadFileFromDisk(stdPath);
        var scoresData = fileReader.ReadFileFromDisk(scrPath);
        var jsonParser = new JsonParser();
        students = jsonParser.ParseStudents(studentsData);
        lessons = jsonParser.ParseScores(scoresData);

        foreach (var lesson in lessons)
            students.Where(x => lesson.StudentNumber == x.StudentNumber).ElementAt(0).RegisterLesson(lesson);
        output.PrintTopStudents(students);
    }
}