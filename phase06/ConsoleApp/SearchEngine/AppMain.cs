using SampleLibrary;
using System.Configuration;

namespace SearchEngine;

public class AppMain
{
    public static void Main(string[] args)
    {
        
        var filesDir = ConfigurationManager.AppSettings["dataDirectoryPath"];
        var fileReader = new FileReader(filesDir);
        new RunProgram().Run(fileReader);
    }
    
}