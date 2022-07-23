import java.util.Scanner;
import java.util.Set;

public class IO {
    public String[] getInput() {
        Scanner scanner = new Scanner(System.in);
        return scanner.nextLine().toUpperCase().split(" ");
    }

    public void print(Set<String> set) {
        System.out.println(set);
    }
}
