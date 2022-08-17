using SampleLibrary;

namespace DefaultNamespace;

public interface IInvertedIndexSearchService
{
    SearchInDocs SearchEngine(String dirPath);
}

public class InvertedIndexSearchService : IInvertedIndexSearchService
{
    public SearchInDocs SearchEngine(String dirPath)
    {
        var documentsDictionary = new FileReader(dirPath).readFiles();
        var invertedIndexMaker = new InvertedIndexMaker(documentsDictionary);
        var invertedIndex = invertedIndexMaker.Make(new InvertedIndex());
        return new SearchInDocs(invertedIndex.Map);
    }
}