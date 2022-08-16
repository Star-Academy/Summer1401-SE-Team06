namespace DefaultNamespace;

public class InputProcessor
{
    public HashSet<string> avoided = new();
    public HashSet<string> necessary = new();
    public HashSet<string> optional = new();

    public void Process(string input)
    {
        optional.Clear();
        necessary.Clear();
        avoided.Clear();
        
        var splittedInput = input.ToUpper().Split(" ");
        foreach (var s in splittedInput)
            if (s.StartsWith("+")) optional.Add(s.Substring(1));
            else if (s.StartsWith("-")) avoided.Add(s.Substring(1));
            else necessary.Add(s);
    }
}