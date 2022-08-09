namespace SampleLibrary;

public class SearchInDocs
{
    private readonly HashSet<string> _avoids = new();
    private readonly Dictionary<string, HashSet<string>> _data;
    private readonly HashSet<string> _necessaries = new();
    private readonly HashSet<string> _optionals = new();

    public SearchInDocs(Dictionary<string, HashSet<string>> map)
    {
        _data = map;
    }

    public HashSet<string> search(HashSet<string> necessaries, HashSet<string> optionals, HashSet<string> avoids)
    {
        InitSet(avoids, _avoids);
        InitSet(optionals, _optionals);
        InitNecessaries(necessaries);

        _optionals.UnionWith(_necessaries);
        _optionals.ExceptWith(_avoids);

        return _optionals;
    }

    private void InitNecessaries(HashSet<string> necessaries)
    {
        foreach (var necessary in necessaries)
            if (_data.ContainsKey(necessary))
            {
                if (_necessaries.Count == 0)
                    _necessaries.UnionWith(_data[necessary]);
                else
                    _necessaries.IntersectWith(_data[necessary]);
            }
    }

    private void InitSet(HashSet<string> wordSet, HashSet<string> allSets)
    {
        foreach (var optional in wordSet)
            if (_data.ContainsKey(optional))
                allSets.UnionWith(_data[optional]);
    }
}