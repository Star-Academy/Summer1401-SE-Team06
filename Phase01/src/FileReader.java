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

    public void readFiles() {
        String content;
        for (File file : Objects.requireNonNull(directory.listFiles())) {
            try {
                content = Files.readString(Paths.get(file.getPath())).toUpperCase();
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            docNameToContent.put(Integer.parseInt(file.getName()), content);
        }
    }

    public HashMap<Integer, String> getDocNameToContent() {
        return docNameToContent;
    }
}
