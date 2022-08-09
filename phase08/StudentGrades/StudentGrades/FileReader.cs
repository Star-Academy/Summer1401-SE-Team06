using System.Net;
using Newtonsoft.Json;

namespace project;

public class FileReader
{
    public string DownloadData(string url)
    {
        using (var wc = new WebClient())
        {
            return wc.DownloadString(url);
        }
    }

    public List<Student> ParseStudents(List<Student> students, string studentsData)
    {
        dynamic studentsJson = JsonConvert.DeserializeObject(studentsData);
        foreach (var item in studentsJson)
            students.Add(new Student
                { FirstName = item.FirstName, LastName = item.LastName, StudentNumber = item.StudentNumber });
        return students;
    }

    public List<Student> ParseScores(List<Student> students, string scoresData)
    {
        dynamic scoresJson = JsonConvert.DeserializeObject(scoresData);
        foreach (var item in scoresJson)
        {
            var student = students.Where(x => x.StudentNumber == (int)item.StudentNumber);
            student.ElementAt(0).AddLesson(new Lesson { Name = item.Lesson, Score = item.Score });
        }

        return students;
    }
}