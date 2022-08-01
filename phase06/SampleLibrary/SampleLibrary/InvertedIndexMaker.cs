using System.Collections.Generic;

namespace SampleLibrary;

public class InvertedIndexMaker
{
    private readonly Dictionary<string, string> _documents;

    public InvertedIndexMaker(Dictionary<string, string> documents)
    {
        this._documents = documents;
    }

    public InvertedIndex Make(InvertedIndex invertedIndex)
    {
        foreach (var doc in _documents)
            invertedIndex.indexDocument(doc.Value, doc.Key);
        return invertedIndex;
    }
}