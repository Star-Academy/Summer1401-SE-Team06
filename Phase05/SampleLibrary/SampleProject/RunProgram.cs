using SampleLibrary;
using SampleProgram;

namespace SampleProject;

public class RunProgram
{
    public void Run(FileReader fileReader)
    {
        var documentsDictionary = fileReader.readFiles();
        var completedInvertedIndex = new InvertedIndex();
        var invertedIndexMaker = new InvertedIndexMaker(documentsDictionary);
        completedInvertedIndex = invertedIndexMaker.Make(completedInvertedIndex);
        
        IOWorks io = new IOWorks();
        String[] input = io.GetInput();

        InputProcessor inputProcessor = new InputProcessor();
        inputProcessor.Process(input);

        SearchInDocs searchInDocs = new SearchInDocs(completedInvertedIndex.Map);
        HashSet<String> result = searchInDocs.search(inputProcessor.necessary,
            inputProcessor.optional, inputProcessor.avoided);

        io.Print(result);
    }
}