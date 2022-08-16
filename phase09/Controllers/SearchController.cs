using DefaultNamespace;
using Microsoft.AspNetCore.Mvc;
using SampleLibrary;

namespace ASP.net.Controllers;

[ApiController]
[Route("[controller]/[Action]")]
public class SearchController : ControllerBase
{
    private readonly InvertedIndex _invertedIndex;
    private readonly InputProcessor _inputProcessor;
    private readonly SearchInDocs _searchInDocs;

    public SearchController()
    {
        Console.WriteLine("1");
        var filesDir = @"EnglishData";
        var fileReader = new FileReader(filesDir);
        Console.WriteLine("2");
        var documentsDictionary = fileReader.readFiles();
        Console.WriteLine("3");
        _invertedIndex = new InvertedIndex(); 
        var invertedIndexMaker = new InvertedIndexMaker(documentsDictionary);
        _invertedIndex = invertedIndexMaker.Make(_invertedIndex);
        _inputProcessor = new InputProcessor();
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