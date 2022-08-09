using FluentAssertions;

namespace SampleLibrary.Test;

public class FileReaderTest
{
    string firstFileData =
        ">This wouldn't happen to be the same thing as chiggers, " +
        "would it>A truly awful parasitic affliction, as I understand it." +
        "  Tiny bug>dig deeply into the skin, burying themselves.  Yuck! " +
        " They have thes>things in OklahomaClose. My mother comes from Gainesville" +
        " Tex, right across the borderThey claim to be the chigger capitol of the world," +
        " and I believe themWhen I grew up in Fort Worth it was bad enough, but in " +
        "Gainesvillin the summer an attack was guaranteedDoug McDonal";
    
    [Fact]
    public void FileReading_ScanAllFilesAndCheckOne_ReturnsTrue()
    {
        var filesDir = @"C:\Users\User\Desktop\EnglishData";
        var fileReader = new FileReader(filesDir);
        var files = fileReader.readFiles();

        files["58043"].Should().Be(firstFileData.ToUpper());
    }
}