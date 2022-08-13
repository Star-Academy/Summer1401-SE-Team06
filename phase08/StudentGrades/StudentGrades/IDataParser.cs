namespace project;

public interface IDataParser
{
    public T Parse<T>(string data);
}