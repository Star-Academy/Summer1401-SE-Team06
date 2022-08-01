using System.Collections;

namespace SampleProject;

public class InputProcessor
{
    public HashSet<string> necessary = new();
    public HashSet<string> optional = new();
    public HashSet<string> avoided = new();

    public void Process(String[] input) {
        foreach (string s in input) {
            if (s.StartsWith("+")) optional.Add(s.Substring(1));
            else if (s.StartsWith("-")) avoided.Add(s.Substring(1));
            else necessary.Add(s);
        }
    }
}