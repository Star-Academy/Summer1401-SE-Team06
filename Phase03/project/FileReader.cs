using System.Net;

namespace project;

public class FileReader
{
    public string ReadFileFromDisk(string filePath)
    {
        string text = File.ReadAllText(filePath);  
        return text;
    }
}