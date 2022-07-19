import java.io.FileNotFoundException;
import java.util.*;

public class Main {
    public static void main(String[] args) throws FileNotFoundException {
        InvertedIndex invertedIndex = preprocess();
        String[] input = getInput();
        Set<Integer> result = processInputAndSearch(input, invertedIndex);

        System.out.println(result);
    }

    private static Set<Integer> processInputAndSearch(String[] input, InvertedIndex invertedIndex) {
        ArrayList<String> necessary = new ArrayList<>();
        ArrayList<String> optional = new ArrayList<>();
        ArrayList<String> avoided = new ArrayList<>();

        for (String s : input) {
            if (s.startsWith("+")) optional.add(s.substring(1));
            else if (s.startsWith("-")) avoided.add(s.substring(1));
            else necessary.add(s);
        }

        return searchInDocs(invertedIndex, necessary, optional, avoided);
    }

    private static Set<Integer> searchInDocs(InvertedIndex invertedIndex, ArrayList<String> necessary, ArrayList<String> optional, ArrayList<String> avoided) {
        HashMap<String, Set<Integer>> invertedIndexMap = invertedIndex.getInvertedIndex();
        Set<Integer> necessaries = new HashSet<>();
        Set<Integer> optionals = new HashSet<>();
        Set<Integer> avoids = new HashSet<>();

        searchNecessaries(necessary, necessaries, invertedIndexMap);
        searchOptionals(optional, optionals, invertedIndexMap);
        searchAvoids(avoided, avoids, invertedIndexMap);


        optionals.addAll(necessaries);
        optionals.removeAll(avoids);

        return optionals;
    }

    private static void searchAvoids(ArrayList<String> avoided, Set<Integer> avoids, HashMap<String, Set<Integer>> invertedIndexMap) {
        for (String s : avoided) {
            if (invertedIndexMap.containsKey(s))
                avoids.addAll(invertedIndexMap.get(s));
        }
    }

    private static void searchOptionals(ArrayList<String> optional, Set<Integer> optionals, HashMap<String, Set<Integer>> invertedIndexMap) {
        for (String s : optional) {
            if (invertedIndexMap.containsKey(s))
                optionals.addAll(invertedIndexMap.get(s));
        }
    }

    private static void searchNecessaries(ArrayList<String> necessary, Set<Integer> necessaries, HashMap<String, Set<Integer>> invertedIndexMap) {
        for (String s : necessary) {
            if (invertedIndexMap.containsKey(s)) {
                if (necessaries.isEmpty())
                    necessaries.addAll(invertedIndexMap.get(s));
                else
                    necessaries.retainAll(invertedIndexMap.get(s));
            }
        }
    }

    private static String[] getInput() {
        Scanner scanner = new Scanner(System.in);
        return scanner.nextLine().toUpperCase().split(" ");
    }

    private static InvertedIndex preprocess() throws FileNotFoundException {
        InvertedIndex invertedIndex = new InvertedIndex();

        for (int i = 58043; i < 58156; i++) {
            FileReader fileReader = new FileReader("Phase01/src/EnglishData/" + i);
            fileReader.readFile();
            String document = fileReader.getDocument();
            invertedIndex.indexDocument(document, i);
        }

        return invertedIndex;
    }
}
