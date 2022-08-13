namespace SearchEngine;

public class ConsoleIO : IInputOutput
{
    public string GetInput()
    {
        return Console.ReadLine();
    }

    public void ShowOutput(IEnumerable<string> output)
    {
        foreach (var s in output)
        {
            Console.WriteLine(s);
        }
    }
}