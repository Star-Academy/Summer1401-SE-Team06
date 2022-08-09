using project;

namespace Project;

internal class App
{
    public static void Main(string[] args)
    {
        var fileReader = new FileReader();
        var output = new Output();
        new RunProgram().Run(fileReader, output);
    }
}
