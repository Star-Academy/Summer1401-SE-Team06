namespace SampleLibrary;

public class InvertedIndexMaker
{
    private readonly Dictionary<string, string> documents = new();
    private readonly InvertedIndex invertedIndex;

    public InvertedIndexMaker(InvertedIndex invertedIndex, Dictionary<string, string> documents)
    {
        this.invertedIndex = invertedIndex;
        this.documents = documents;
    }

    public void make()
    {
        foreach (var doc in documents) 
            invertedIndex.indexDocument(doc.Value, doc.Key);
    }
}