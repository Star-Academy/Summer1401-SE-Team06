namespace project;

public class FileReader
{
    public string ReadFileFromDisk(string filePath)
    {
        return File.ReadAllText(filePath);
    }
}