using DefaultNamespace;
using Microsoft.AspNetCore.Mvc;
using SampleLibrary;

namespace ASP.net.Controllers;

[ApiController]
[Route("[controller]/[Action]")]
public class SearchController : ControllerBase
{
    private const string FilesDir = @"EnglishData";
    private readonly InputProcessor _inputProcessor;
    private readonly SearchInDocs _searchInDocs;

    public SearchController()
    {
        _inputProcessor = new InputProcessor();
        var documentsDictionary = new FileReader(FilesDir).readFiles();
        var invertedIndexMaker = new InvertedIndexMaker(documentsDictionary);
        var _invertedIndex = invertedIndexMaker.Make(new InvertedIndex());
        _searchInDocs = new SearchInDocs(_invertedIndex.Map);
    }

    [HttpGet]
    public IEnumerable<string> Search(string query)
    {
        _inputProcessor.Process(query);
        HashSet<string> result = _searchInDocs.search(_inputProcessor.necessary,
            _inputProcessor.optional, _inputProcessor.avoided);
        return result;
    }
}