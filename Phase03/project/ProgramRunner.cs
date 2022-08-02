namespace project;

public class ProgramRunner
{
    public void Run()
    {
        var fileReader = new FileReader();
        var output = new OutputPrinter();
        var students = new List<Student>();
        var studentsData =
            fileReader.DownloadData(
                "https://docs.code-star.ir/assets/files/students-7e48b111d2450c4a8dc0ffe4fc912c36.json");
        var scoresData =
            fileReader.DownloadData(
                "https://docs.code-star.ir/assets/files/scores-76885bff66d5238dfd0661c6ac6d74fc.json");

        var jsonParser = new JsonParser();
        students = jsonParser.ParseStudents(studentsData);
        students = jsonParser.ParseScores(students, scoresData);
        output.PrintTopStudents(students);
    }
}