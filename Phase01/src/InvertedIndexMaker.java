import java.util.HashMap;

public class InvertedIndexMaker {
    private final InvertedIndex invertedIndex;
    private final FileReader fileReader;

    public InvertedIndexMaker(FileReader fileReader) {
        this.invertedIndex = new InvertedIndex();
        this.fileReader = fileReader;
    }

    public void make() throws InputException {
        fileReader.readFiles();
        HashMap<String, String> docNameToContent = fileReader.getDocNameToContent();

        for (String docName : docNameToContent.keySet()) {
            invertedIndex.indexDocument(docNameToContent.get(docName), docName);
        }
    }

    public InvertedIndex getInvertedIndex() {
        return invertedIndex;
    }
}
