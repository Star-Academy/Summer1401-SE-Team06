import java.util.HashMap;
import java.util.HashSet;
import java.util.Set;

public class InvertedIndex {
    private static final HashMap<String, Set<Integer>> invertedIndex = new HashMap<>();

    public HashMap<String, Set<Integer>> getInvertedIndex() {
        return invertedIndex;
    }

    public void indexDocument(String document, int docID) {
        String[] words;

        words = document.split(" ");
        for (String word : words)
            if (word.length() > 1)
                add_word(word, docID);
    }

    private void add_word(String word, int docID) {
        boolean wordExists = invertedIndex.containsKey(word);
        Set<Integer> list;

        if (wordExists) list = invertedIndex.get(word);
        else list = new HashSet<>();

        list.add(docID);
        invertedIndex.put(word, list);
    }
}
