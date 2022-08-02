using System.Net;

namespace project;

public class FileReader
{
    public string DownloadData(string url)
    {
        using (var webClient = new WebClient())
        {
            return webClient.DownloadString(url);
        }
    }
}