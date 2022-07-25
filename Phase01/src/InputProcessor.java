import java.util.ArrayList;

public class InputProcessor {
    private final ArrayList<String> necessary = new ArrayList<>();
    private final ArrayList<String> optional = new ArrayList<>();
    private final ArrayList<String> avoided = new ArrayList<>();

    public ArrayList<String> getNecessary() {
        return necessary;
    }

    public ArrayList<String> getOptional() {
        return optional;
    }

    public ArrayList<String> getAvoided() {
        return avoided;
    }

    public void process(String[] input) {
        for (String s : input) {
            if (s.startsWith("+")) optional.add(s.substring(1));
            else if (s.startsWith("-")) avoided.add(s.substring(1));
            else necessary.add(s);
        }
    }
}
