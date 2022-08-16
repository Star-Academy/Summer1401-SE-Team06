using FluentAssertions;

namespace SampleLibrary.Test;

public class SearchEngineTest
{
    private Dictionary<string, HashSet<string>> _dataMap;

    public SearchEngineTest()
    {
        Initialize();
    }

    private void Initialize()
    {
        _dataMap = new Dictionary<string, HashSet<string>>();

        _dataMap["ali"] = new HashSet<string> { "1", "3", "7", "5" };
        _dataMap["mohammad"] = new HashSet<string> { "1", "2", "5", "6" };
        _dataMap["amir"] = new HashSet<string> { "1", "6", "4" };
        _dataMap["mahdi"] = new HashSet<string> { "1", "4", "3", "6" };
    }

    [Theory]
    [MemberData(nameof(BuildQueryData))]
    public void SearchInDocsTest_ContainingDocs_ReturnsTrue(WordContainer wordContainer)
    {
        var searchInDocs = new SearchInDocs(_dataMap);
        var searched = searchInDocs.search(wordContainer);
        searched.Should().Contain("3");
        searched.Should().Contain("5");
        searched.Should().Contain("7");
    }

    [Theory]
    [MemberData(nameof(BuildQueryData))]
    public void SearchInDocsTest_NotContainingDocs_ReturnsFalse(WordContainer wordContainer)
    {
        var searchInDocs = new SearchInDocs(_dataMap);
        var searched = searchInDocs.search(wordContainer);

        searched.Should().NotContain("1");
        searched.Should().NotContain("2");
        searched.Should().NotContain("4");
        searched.Should().NotContain("6");
    }

    public static IEnumerable<object[]> BuildQueryData()
    {
        yield return new object[]
        {
            new WordContainer(new HashSet<string> { "amir" }, new HashSet<string> { "ali" },
                new HashSet<string> { "mahdi" })
        };
    }
}