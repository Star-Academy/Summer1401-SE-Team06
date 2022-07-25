import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Set;

public class SearchInDocs {
    private final HashMap<String, Set<String>> invertedIndexMap;
    private final Set<String> necessaries = new HashSet<>();
    private final Set<String> optionals = new HashSet<>();
    private final Set<String> avoids = new HashSet<>();

    public SearchInDocs(HashMap<String, Set<String>> invertedIndexMap) {
        this.invertedIndexMap = invertedIndexMap;
    }

    public Set<String> search(ArrayList<String> necessary, ArrayList<String> optional, ArrayList<String> avoided) {
        searchNecessaries(necessary, necessaries, invertedIndexMap);
        searchOptionals(optional, optionals, invertedIndexMap);
        searchAvoids(avoided, avoids, invertedIndexMap);

        optionals.addAll(necessaries);
        optionals.removeAll(avoids);

        return optionals;
    }

    private void searchAvoids(ArrayList<String> avoided, Set<String> avoids, HashMap<String, Set<String>> invertedIndexMap) {
        for (String word : avoided) {
            if (invertedIndexMap.containsKey(word)) {
                avoids.addAll(invertedIndexMap.get(word));
            }
        }
    }

    private void searchOptionals(ArrayList<String> optional, Set<String> optionals, HashMap<String, Set<String>> invertedIndexMap) {
        for (String word : optional) {
            if (invertedIndexMap.containsKey(word)) {
                optionals.addAll(invertedIndexMap.get(word));
            }
        }
    }

    private void searchNecessaries(ArrayList<String> necessary, Set<String> necessaries, HashMap<String, Set<String>> invertedIndexMap) {
        for (String word : necessary) {
            if (invertedIndexMap.containsKey(word)) {
                if (necessaries.isEmpty()) {
                    necessaries.addAll(invertedIndexMap.get(word));
                } else {
                    necessaries.retainAll(invertedIndexMap.get(word));
                }
            }
        }
    }
}
