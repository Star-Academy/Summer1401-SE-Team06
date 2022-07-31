namespace SampleLibrary;

public class InvertedIndex
{
    public Dictionary<string, HashSet<string>> Map { get; } = new();

    public void indexDocument(string document, string docId)
    {
        string[] words;

        words = document.Split(" ");

        foreach (var word in words)
            if (word.Length > 1)
                AddWordToMap(word, docId);
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