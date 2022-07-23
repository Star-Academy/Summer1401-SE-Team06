import java.util.Set;

public class AppController {

    public void run() {
        InvertedIndex invertedIndex = new InvertedIndex();
        FileReader fileReader = new FileReader("Phase01/src/EnglishData/");
        MakeInvertedIndex makeInvertedIndex = new MakeInvertedIndex(invertedIndex, fileReader);

        makeInvertedIndex.make();
        invertedIndex = makeInvertedIndex.getInvertedIndex();

        IO io = new IO();
        String[] input = io.getInput();

        InputProcessor inputProcessor = new InputProcessor();
        inputProcessor.process(input);

        SearchInDocs searchInDocs = new SearchInDocs(invertedIndex.getInvertedIndex());
        Set<Integer> result = searchInDocs.search(inputProcessor.getNecessary(),
                inputProcessor.getOptional(), inputProcessor.getAvoided());

        io.print(result);
    }
}
