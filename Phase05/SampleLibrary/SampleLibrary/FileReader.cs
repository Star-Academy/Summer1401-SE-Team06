namespace SampleLibrary;

public class FileReader
{
    private readonly string _filesDir;

    public FileReader(string filesDir)
    {
        _filesDir = filesDir;
    }

    public Dictionary<string, string> readFiles()
    {
        var allFilesText = new Dictionary<string, string>();
        var di = new DirectoryInfo(_filesDir);
        Parallel.ForEach(di.GetFiles("*", SearchOption.TopDirectoryOnly),
            file => { allFilesText[file.Name] = File.ReadAllText(file.FullName).ToUpper(); });

        return allFilesText;
    }
}