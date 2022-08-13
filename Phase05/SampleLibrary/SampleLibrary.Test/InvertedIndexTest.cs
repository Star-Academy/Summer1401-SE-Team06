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

    [Fact]
    public void InvertedIndex_ExistingWords_ReturnsTrue()
    {
        var map = _invertedIndex.Map;

        map.ContainsKey("hello").Should().Be(true);
        map.ContainsKey("ali").Should().Be(true);
    }


    [Fact]
    public void InvertedIndex_NotExistingWords_ReturnsFalse()
    {
        var map = _invertedIndex.Map;

        map.ContainsKey("mohammad").Should().NotBe(true);
        map.ContainsKey("test").Should().NotBe(true);
    }

    [Fact]
    public void InvertedIndex_DocsContainingAWord_ReturnsTrue()
    {
        var map = _invertedIndex.Map;
        var value = new HashSet<string>();

        if (map.TryGetValue("ali", out value))
        {
            value.Should().Contain("1");
            value.Should().Contain("4");
        }
    }

    [Fact]
    public void InvertedIndex_DocsNotContainingAWord_ReturnsTrue()
    {
        var map = _invertedIndex.Map;

        var value = new HashSet<string>();

        if (map.TryGetValue("ali", out value))
        {
            value.Should().NotContain("2");
            value.Should().NotContain("3");
        }
    }
}