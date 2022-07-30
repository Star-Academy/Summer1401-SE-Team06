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
}