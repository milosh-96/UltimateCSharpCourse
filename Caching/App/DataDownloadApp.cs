using CustomCache.Caching;
using CustomCache.Data;

namespace CustomCache.App;

public class DataDownloadApp : IApp
{
    public void Run()
    {
        IDataDownloader dataDownloader = new SlowDataDownloader(new CachingManager());
        Console.WriteLine(dataDownloader.DownloadData("id1"));
        Console.WriteLine(dataDownloader.DownloadData("id2"));
        Console.WriteLine(dataDownloader.DownloadData("id3"));
        Console.WriteLine(dataDownloader.DownloadData("id1"));
        Console.WriteLine(dataDownloader.DownloadData("id3"));
        Console.WriteLine(dataDownloader.DownloadData("id1"));
        Console.WriteLine(dataDownloader.DownloadData("id2"));
    }
}
