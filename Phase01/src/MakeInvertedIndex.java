import java.util.HashMap;

public class MakeInvertedIndex {
    private final InvertedIndex invertedIndex;
    private final FileReader fileReader;

    public MakeInvertedIndex(FileReader fileReader) {
        this.invertedIndex = new InvertedIndex();
        this.fileReader = fileReader;
    }

    public void make() throws InputException {
        fileReader.readFiles();
        HashMap<Integer, String> docNameToContent = fileReader.getDocNameToContent();

        for (Integer i : docNameToContent.keySet()) {
            invertedIndex.indexDocument(docNameToContent.get(i), i);
        }
    }

    public InvertedIndex getInvertedIndex() {
        return invertedIndex;
    }
}
