import java.util.HashMap;
import java.util.HashSet;
import java.util.Set;

public class InvertedIndex {
    private static final HashMap<String, Set<String>> invertedIndex = new HashMap<>();

    public HashMap<String, Set<String>> getInvertedIndex() {
        return invertedIndex;
    }

    public void indexDocument(String document, String docID) {
        String[] words;

        words = document.split(" ");
        for (String word : words)
            if (word.length() > 1)
                add_word(word, docID);
    }

    private void add_word(String word, String docID) {
        boolean wordExists = invertedIndex.containsKey(word);
        Set<String> list;

        if (wordExists) list = invertedIndex.get(word);
        else list = new HashSet<>();

        list.add(docID);
        invertedIndex.put(word, list);
    }
}
