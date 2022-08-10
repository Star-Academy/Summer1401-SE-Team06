using DefaultNamespace;

namespace project;

public class ProgramRunner
{
    public void Run()
    {
        var schoolContext = new SchoolDBContext();
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
        AddRecordsToDB(students, lessons, schoolContext);
        calculateAverageGrade(schoolContext);
        output.PrintTopStudents(students);
    }

    private void calculateAverageGrade(SchoolDBContext schoolContext)
    {
        foreach (var student in schoolContext.Students)
        {
            var studentAverage = schoolContext.StudentGrades.Where(x => x.StudentNumber == student.StudentNumber).Average(x => x.Score);
            student.AverageGrade = studentAverage;
            schoolContext.Update(student);

        }
    }

    private void AddRecordsToDB(List<Student> students, List<StudentGrade> lessons, SchoolDBContext schoolContext)
    {
        schoolContext.Students.AddRange(students);
        schoolContext.StudentGrades.AddRange(lessons);
        schoolContext.SaveChanges();
       
    }
}