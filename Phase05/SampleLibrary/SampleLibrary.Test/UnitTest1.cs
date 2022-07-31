using FluentAssertions;

namespace SampleLibrary.Test;

public class UnitTest1
{
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
    public void InvertedIndexTest()
    {
        var invertedIndex = new InvertedIndex();

        invertedIndex.indexDocument("hello ali", "1");
        invertedIndex.indexDocument("this is a code", "2");
        invertedIndex.indexDocument("to search some words", "3");
        invertedIndex.indexDocument("in a text, ali", "4");

        var map = invertedIndex.Map;

        map.ContainsKey("hello").Should().Be(true);
        map.ContainsKey("mohammad").Should().NotBe(true);

        map["ali"].Contains("1").Should().Be(true);
        map["ali"].Contains("4").Should().Be(true);

        map["ali"].Contains("2").Should().Be(false);
    }

    [Fact]
    public void InvertedIndexMakerTest()
    {
        var documents = new Dictionary<string, string>();
        documents["1"] = "hello ali";
        documents["2"] = "this is a code";
        documents["3"] = "to search some words";
        documents["4"] = "in a text, ali";

        var invertedIndex = new InvertedIndex();
        var invertedIndexMaker = new InvertedIndexMaker(invertedIndex, documents);
        invertedIndexMaker.make();

        var map = invertedIndex.Map;

        map.ContainsKey("hello").Should().Be(true);
        map.ContainsKey("mohammad").Should().NotBe(true);

        map["ali"].Contains("1").Should().Be(true);
        map["ali"].Contains("4").Should().Be(true);

        map["ali"].Contains("2").Should().Be(false);
    }

    [Fact]
    public void SearchInDocsTest()
    {
        var map = new Dictionary<string, HashSet<string>>();

        var avoids = new HashSet<string> { "amir" };
        var necessaries = new HashSet<string> { "ali" };
        var optionals = new HashSet<string> { "mahdi" };

        map["ali"] = new HashSet<string> { "1", "3", "7", "5" };
        map["mohammad"] = new HashSet<string> { "1", "2", "5", "6" };
        map["amir"] = new HashSet<string> { "1", "6", "4" };
        map["mahdi"] = new HashSet<string> { "1", "4", "3", "6" };

        var searchInDocs = new SearchInDocs(map);
        var searched = searchInDocs.search(necessaries, optionals, avoids);

        searched.Contains("1").Should().NotBe(true);
        searched.Contains("2").Should().NotBe(true);
        searched.Contains("3").Should().Be(true);
        searched.Contains("4").Should().NotBe(true);
        searched.Contains("5").Should().Be(true);
        searched.Contains("6").Should().NotBe(true);
        searched.Contains("7").Should().Be(true);
    }
}