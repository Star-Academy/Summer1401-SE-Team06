using System.Net;
using Newtonsoft.Json;

namespace project;

public class FileReader
{
    public string DownloadData(string url)
    {
        using (var wc = new WebClient())
        {
            return wc.DownloadString(url);
        }
    }
}