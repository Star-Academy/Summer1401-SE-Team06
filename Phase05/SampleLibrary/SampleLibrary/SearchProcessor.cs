namespace SampleLibrary;

public class SearchProcessor
{
    private static SearchProcessor instance;

    private SearchProcessor()
    {
    }

    public static SearchProcessor Instance
    {
        get
        {
            if (instance == null) instance = new SearchProcessor();
            return instance;
        }
    }

    public WordContainer process(WordContainer wordContainer, Dictionary<string, HashSet<string>> data)
    {
        var finalWords =
            new WordContainer(new HashSet<string>(), new HashSet<string>(), new HashSet<string>());
        InitSet(wordContainer.Avoids, finalWords.Avoids, data);
        InitSet(wordContainer.Optionals, finalWords.Optionals, data);
        InitNecessaries(wordContainer.Necessaries, finalWords.Necessaries, data);

        return finalWords;
    }

    private void InitNecessaries(HashSet<string> wordSet, HashSet<string> allSets,
        Dictionary<string, HashSet<string>> data)
    {
        foreach (var necessary in wordSet)
            if (data.ContainsKey(necessary))
            {
                if (allSets.Any())
                    allSets.UnionWith(data[necessary]);
                else
                    allSets.IntersectWith(data[necessary]);
            }
    }

    private void InitSet(HashSet<string> wordSet, HashSet<string> allSets, Dictionary<string, HashSet<string>> data)
    {
        foreach (var optional in wordSet)
            if (data.ContainsKey(optional))
                allSets.UnionWith(data[optional]);
    }
}