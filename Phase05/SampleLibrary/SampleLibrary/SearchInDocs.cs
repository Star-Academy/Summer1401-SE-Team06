namespace SampleLibrary;

public class SearchInDocs
{
    private readonly Dictionary<string, HashSet<string>> _data;

    public SearchInDocs(Dictionary<string, HashSet<string>> map)
    {
        _data = map;
    }

    public HashSet<string> search(WordContainer wordContainer)
    {
        var searchProcessor = SearchProcessor.Instance;
        var finalWords = searchProcessor.process(wordContainer, _data);

        finalWords.Optionals.UnionWith(finalWords.Necessaries);
        finalWords.Optionals.ExceptWith(finalWords.Avoids);
        
        return finalWords.Optionals;
    }
}