using FluentAssertions;

namespace SampleLibrary.Test;

public class SearchEngineTest
{
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