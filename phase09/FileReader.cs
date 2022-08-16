// Decompiled with JetBrains decompiler
// Type: SampleLibrary.FileReader
// Assembly: SampleLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C2F12150-A9A2-45E5-84CC-FA8162D0F5BE
// Assembly location: C:\Users\User\.nuget\packages\staracademy.codestar1401.team06.searchengine\1.0.1\lib\net6.0\SampleLibrary.dll

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
        Parallel.ForEach(new DirectoryInfo(filesDir).GetFiles("*", SearchOption.TopDirectoryOnly),
            file => allFilesText[file.Name] = File.ReadAllText(file.FullName).ToUpper());
        return allFilesText;
    }
}