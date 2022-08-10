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

        var stdPath = @"studentsData.json";
        var scrPath = @"scoresData.json";
        var studentsData = fileReader.ReadFileFromDisk(stdPath);
        var scoresData = fileReader.ReadFileFromDisk(scrPath);
        var jsonParser = new JsonParser();
        students = jsonParser.ParseStudents(studentsData);
        lessons = jsonParser.ParseScores(scoresData);
        AddRecordsToDB(students, lessons);
        // foreach (var lesson in lessons)
        //     students.Where(x => lesson.StudentNumber == x.StudentNumber).ElementAt(0).RegisterLesson(lesson);
        output.PrintTopStudents(students);
    }

    private void AddRecordsToDB(List<Student> students, List<StudentGrade> lessons)
    {
        using (var context = new SchoolDBContext()) {
            context.Students.AddRange(students);
            context.StudentGrades.AddRange(lessons);
            context.SaveChanges();
        }
    }
}