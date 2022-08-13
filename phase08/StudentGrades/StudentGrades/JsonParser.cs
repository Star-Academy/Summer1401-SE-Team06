using Newtonsoft.Json;

namespace project;

public class JsonParser : IDataParser
{
    public T Parse<T>(string data)
    {
        return JsonConvert.DeserializeObject<T>(data);
    }

    public List<Student> ParseStudents(string studentsData)
    {
        return JsonConvert.DeserializeObject<List<Student>>(studentsData);
    }

    public List<StudentGrade> ParseScores(string scoresData)
    {
        return JsonConvert.DeserializeObject<List<StudentGrade>>(scoresData);
    }
}