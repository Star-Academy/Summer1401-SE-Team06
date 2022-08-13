using Newtonsoft.Json;

namespace project;

public class JsonParser
{
    public List<Student> ParseStudents(string studentsData)
    {
        return JsonConvert.DeserializeObject<List<Student>>(studentsData);
    }

    public List<Lesson> ParseScores(string scoresData)
    {
        return JsonConvert.DeserializeObject<List<Lesson>>(scoresData);
    }
}