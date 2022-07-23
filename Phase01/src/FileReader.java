import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Objects;

public class FileReader {
    private final HashMap<Integer, String> docNameToContent = new HashMap<>();
    private final File directory;

    public FileReader(String fileAddress) {
        this.directory = new File(fileAddress);
    }

    public HashMap<Integer, String> getDocNameToContent() {
        return docNameToContent;
    }

    public void readFiles() throws InputException {
        String content;
        for (File file : Objects.requireNonNull(directory.listFiles())) {
            content = readFile(file);
            String fileName = file.getName();
            putInMap(fileName, content);
        }
    }

    private void putInMap(String fileName, String content) {
        docNameToContent.put(Integer.parseInt(fileName), content);
    }

    private String readFile(File file) throws InputException {
        String content;
        try {
            content = Files.readString(Paths.get(file.getPath())).toUpperCase();
        } catch (IOException e) {
            throw new InputException("Problem in Reading files!");
        }

        return content;
    }
}
