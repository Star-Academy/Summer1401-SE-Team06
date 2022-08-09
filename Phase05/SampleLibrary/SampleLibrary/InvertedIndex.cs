namespace SampleLibrary;

public class InvertedIndex
{
    public Dictionary<string, HashSet<string>> Map { get; } = new();

    public void indexDocument(string document, string docId)
    {
        document.Split(" ").Where(word => word.Length > 1).ToList().ForEach(word => AddWordToMap(word, docId));
    }

    private void AddWordToMap(string word, string docId)
    {
        var wordExists = Map.ContainsKey(word);
        HashSet<string> docIdSet;

        if (wordExists)
            docIdSet = Map[word];
        else
            docIdSet = new HashSet<string>();

        docIdSet.Add(docId);
        Map[word] = docIdSet;
    }
}