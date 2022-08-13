using Newtonsoft.Json;

namespace project;

public class JsonParser : IDataParser
{
    public T Parse<T>(string data)
    {
        return JsonConvert.DeserializeObject<T>(data);
    }
}