using FluentAssertions;

namespace SampleLibrary.Test;

public class InvertedIndexTest
{
    private InvertedIndex _invertedIndex;

    public InvertedIndexTest()
    {
        InitInvertedIndex();
    }

    private void InitInvertedIndex()
    {
        _invertedIndex = new InvertedIndex();
        _invertedIndex.indexDocument("hello ali", "1");
        _invertedIndex.indexDocument("this is a code", "2");
        _invertedIndex.indexDocument("to search some words", "3");
        _invertedIndex.indexDocument("in a text, ali", "4");
    }

    [Theory]
    [InlineData("ali")]
    [InlineData("hello")]
    public void InvertedIndex_ExistingWords_ReturnsTrue(string content)
    {
        var map = _invertedIndex.Map;

        map.ContainsKey(content).Should().Be(true);
    }


    [Theory]
    [InlineData("mohammad")]
    [InlineData("test")]
    public void InvertedIndex_NotExistingWords_ReturnsFalse(string content)
    {
        var map = _invertedIndex.Map;

        map.ContainsKey(content).Should().NotBe(true);
    }

    [Fact]
    public void InvertedIndex_DocsContainingAWord_ReturnsTrue()
    {
        var map = _invertedIndex.Map;
        var actual = new HashSet<string>();

        if (map.TryGetValue("ali", out actual))
        {
            var expected = new HashSet<string> { "1", "4" };
            actual.Should().Contain(expected);
        }
        else
        {
            throw new KeyNotFoundException();
        }
    }

    [Fact]
    public void InvertedIndex_DocsNotContainingAWord_ReturnsTrue()
    {
        var map = _invertedIndex.Map;

        var actual = new HashSet<string>();

        if (map.TryGetValue("ali", out actual))
        {
            var unexpected = new HashSet<string> { "2", "3" };
            actual.Should().NotContain(unexpected);
        }
        else
        {
            throw new KeyNotFoundException();
        }
    }
}