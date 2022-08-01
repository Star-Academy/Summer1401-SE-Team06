using SampleLibrary;

namespace SampleProgram;

public class AppMain
{
    public static void Main(string[] args)
    {
        var fileReader = new FileReader("C:/Users/User/Desktop/EnglishData");
        
        new RunProgram().Run(fileReader);
    }
    
}