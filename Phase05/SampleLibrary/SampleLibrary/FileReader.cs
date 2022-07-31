namespace SampleLibrary;

public class FileReader
{
    private readonly string filesDir;

    public FileReader(string filesDir)
    {
        this.filesDir = filesDir;
    }

    public Dictionary<string, string> readFiles()
    {
        var allFilesText = new Dictionary<string, string>();
        var di = new DirectoryInfo(filesDir);
        Parallel.ForEach(di.GetFiles("*", SearchOption.TopDirectoryOnly),
            file =>
            {
                allFilesText[file.Name] = File.ReadAllText(file.FullName).ToUpper();
            });

        return allFilesText;
    }
}