namespace DefaultNamespace;

public interface IInputProcessorService
{
    HashSet<string> avoided { get; set; }
    HashSet<string> necessary { get; set; }
     HashSet<string> optional { get; set; } 
    void Process(string input);
}

public class InputProcessorService : IInputProcessorService
{
    public HashSet<string> avoided { get; set; }
    public HashSet<string> necessary { get; set; }
    public HashSet<string> optional { get; set; }

    public void Process(string input)
    {
        optional= new();
        necessary= new();
        avoided= new();
        
        var splittedInput = input.ToUpper().Split(" ");
        foreach (var s in splittedInput)
            if (s.StartsWith("+")) optional.Add(s.Substring(1));
            else if (s.StartsWith("-")) avoided.Add(s.Substring(1));
            else necessary.Add(s);
    }
}