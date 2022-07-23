import java.util.Set;

public class AppController {

    public void run() throws InputException {
        FileReader fileReader = new FileReader("Phase01/src/EnglishData/");
        MakeInvertedIndex makeInvertedIndex = new MakeInvertedIndex(fileReader);

        makeInvertedIndex.make();
        InvertedIndex invertedIndex = makeInvertedIndex.getInvertedIndex();

        IO io = new IO();
        String[] input = io.getInput();

        InputProcessor inputProcessor = new InputProcessor();
        inputProcessor.process(input);

        SearchInDocs searchInDocs = new SearchInDocs(invertedIndex.getInvertedIndex());
        Set<String> result = searchInDocs.search(inputProcessor.getNecessary(),
                inputProcessor.getOptional(), inputProcessor.getAvoided());

        io.print(result);
    }
}
