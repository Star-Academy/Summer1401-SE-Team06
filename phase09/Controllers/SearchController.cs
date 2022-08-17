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

    public SearchController(IInvertedIndexSearchService searchService, InputProcessor inputProcessor)
    {
        _searchInDocs = searchService.SearchEngine(FilesDir); 
        _inputProcessor = inputProcessor;
    }

    [HttpGet]
    public ActionResult<IEnumerable<string>> Search(string query)
    {
        if (string.IsNullOrEmpty(query)) return BadRequest("Invalid query");

        _inputProcessor.Process(query);
        HashSet<string> result = _searchInDocs.search(_inputProcessor.necessary,
            _inputProcessor.optional, _inputProcessor.avoided);
        return result.Any() ? Ok(result) : NotFound();
    }
}