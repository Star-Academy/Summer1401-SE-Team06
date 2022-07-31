using FluentAssertions;

namespace SampleLibrary.Test;

public class UnitTest1
{
    [Theory]
    [InlineData(new[] { "expected", "another" }, new[] { "expected", "another" }, new[] { "expected", "another" })]
    public void Test1(string[] necessaries, string[] optionals, string[] avoids)
    {
        var search = new SearchInDocs(necessaries, optionals, avoids);
        search.Should().Be("");
    }

    [Fact]
    public void FileReaderTest()
    {
        var filesDir = @"C:\Users\alibn\RiderProjects\Summer1401-SE-Team06\Phase05\SampleLibrary\EnglishData";
        var fileReader = new FileReader(filesDir);
        var files = fileReader.readFiles();

        var firstFileData =
            ">This wouldn't happen to be the same thing as chiggers, " +
            "would it>A truly awful parasitic affliction, as I understand it." +
            "  Tiny bug>dig deeply into the skin, burying themselves.  Yuck! " +
            " They have thes>things in OklahomaClose. My mother comes from Gainesville" +
            " Tex, right across the borderThey claim to be the chigger capitol of the world," +
            " and I believe themWhen I grew up in Fort Worth it was bad enough, but in " +
            "Gainesvillin the summer an attack was guaranteedDoug McDonal";

        files["58043"].Should().Be(firstFileData.ToUpper());
    }

    [Fact]
    public void InvertedIndexMakerTest()
    {
        InvertedIndex invertedIndex = new InvertedIndex();

        invertedIndex.indexDocument("hello ali", "1");
        invertedIndex.indexDocument("this is a code", "2");
        invertedIndex.indexDocument("to search some words","3");
        invertedIndex.indexDocument("in a text, ali", "4");

        var map = invertedIndex.Map;

        map.ContainsKey("hello").Should().Be(true);
        map.ContainsKey("mohammad").Should().NotBe(true);
        
        map["ali"].Contains("1").Should().Be(true);
        map["ali"].Contains("4").Should().Be(true);
        
        map["ali"].Contains("2").Should().Be(false);
    }
}