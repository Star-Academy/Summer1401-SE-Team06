import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class FileReader {
    private final Scanner scanner;
    private String document;

    public FileReader(String fileAddress) throws FileNotFoundException {
        File file = new File(fileAddress);
        scanner = new Scanner(file);
    }

    public void readFile() {
        StringBuilder stringBuilder = new StringBuilder();

        while (scanner.hasNextLine())
            stringBuilder.append(scanner.nextLine());

        document = stringBuilder.toString().toUpperCase();
    }

    public String getDocument() {
        return document;
    }
}
