namespace SearchEngine;

public interface IInputOutput
{
    public String GetInput();
    public void ShowOutput(IEnumerable<string> output);
}