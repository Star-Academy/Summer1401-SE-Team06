using SampleLibrary;

namespace SearchEngine;

public class AppMain
{
    public static void Main(string[] args)
    {
        var filesDir = @"SearchEngine/EnglishData";
        var fileReader = new FileReader(filesDir);
        new RunProgram().Run(fileReader);
    }
    
}