using FluentAssertions;

namespace SampleLibrary.Test;

public class InvertedIndexTest
{
    [Fact]
    public void InvertedIndex_InsertSomeWords_ReturnsTrue()
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
    public void InvertedIndexMaker_InsetSomeWordsInInvertedIndex_ReturnsTrue()
    {
        var documents = new Dictionary<string, string>();
        documents["1"] = "hello ali";
        documents["2"] = "this is a code";
        documents["3"] = "to search some words";
        documents["4"] = "in a text, ali";

        var completedInvertedIndex = new InvertedIndex();
        var invertedIndexMaker = new InvertedIndexMaker(documents);
        completedInvertedIndex = invertedIndexMaker.Make(completedInvertedIndex);

        var map = completedInvertedIndex.Map;

        map.ContainsKey("hello").Should().Be(true);
        map.ContainsKey("mohammad").Should().NotBe(true);

        map["ali"].Contains("1").Should().Be(true);
        map["ali"].Contains("4").Should().Be(true);

        map["ali"].Contains("2").Should().Be(false);
    }
}