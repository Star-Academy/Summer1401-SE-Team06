namespace SearchEngine;

public class IOWorks
{
    public String[] GetInput()
    {
        string input = Console.ReadLine();
        return input.ToUpper().Split(" ");
    }

    public void Print(HashSet<string> set) {
        foreach (var element in set)
        {
            Console.WriteLine(element);
        }
    }
}