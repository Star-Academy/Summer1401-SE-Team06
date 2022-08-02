using SampleLibrary;

namespace SearchEngine;

public class RunProgram
{
    public void Run(FileReader fileReader)
    {
        var documentsDictionary = fileReader.readFiles();
        var completedInvertedIndex = new InvertedIndex();
        var invertedIndexMaker = new InvertedIndexMaker(documentsDictionary);
        completedInvertedIndex = invertedIndexMaker.Make(completedInvertedIndex);

        var io = new IOWorks();
        var input = io.GetInput();

        var inputProcessor = new InputProcessor();
        inputProcessor.Process(input);

        var searchInDocs = new SearchInDocs(completedInvertedIndex.Map);
        HashSet<string> result = searchInDocs.search(inputProcessor.necessary,
            inputProcessor.optional, inputProcessor.avoided);

        io.Print(result);
    }
}