namespace SampleLibrary;

public class WordContainer
{
    public WordContainer(HashSet<string> avoids, HashSet<string> necessaries, HashSet<string> optionals)
    {
        Avoids = avoids;
        Necessaries = necessaries;
        Optionals = optionals;
    }


    public HashSet<string> Avoids { get; }
    public HashSet<string> Necessaries { get; }
    public HashSet<string> Optionals { get; }
}