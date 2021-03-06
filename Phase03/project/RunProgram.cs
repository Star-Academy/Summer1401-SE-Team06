namespace project;

public class RunProgram
{
    public void Run(FileReader fileReader, Output output)
    {
        var students = new List<Student>();
        var studentsData =
            fileReader.DownloadData(
                "https://docs.code-star.ir/assets/files/students-7e48b111d2450c4a8dc0ffe4fc912c36.json");
        var scoresData =
            fileReader.DownloadData(
                "https://docs.code-star.ir/assets/files/scores-76885bff66d5238dfd0661c6ac6d74fc.json");
        students = fileReader.ParseStudents(students, studentsData);
        students = fileReader.ParseScores(students, scoresData);
        output.printTopStudents(students);
    }
}