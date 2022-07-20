import java.util.ArrayList;
import java.util.HashMap;
import java.util.Scanner;
import java.util.Set;

public class Main {
    public static void main(String[] args) {
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
        SearchInDocs searchInDocs = new SearchInDocs(invertedIndex.getInvertedIndex());
        return searchInDocs.search(necessary, optional, avoided);
    }


    private static String[] getInput() {
        Scanner scanner = new Scanner(System.in);
        return scanner.nextLine().toUpperCase().split(" ");
    }

    private static InvertedIndex preprocess() {
        InvertedIndex invertedIndex = new InvertedIndex();

        FileReader fileReader = new FileReader("Phase01/src/EnglishData/");
        fileReader.readFiles();
        HashMap<Integer, String> docNameToContent = fileReader.getDocNameToContent();

        for (Integer i : docNameToContent.keySet())
            invertedIndex.indexDocument(docNameToContent.get(i), i);

        return invertedIndex;
    }
}
