using CustomCache.Caching;
using CustomCache.Data;

namespace CustomCache.App;

public class DataDownloadApp : IApp
{
    public void Run()
    {
        IDataDownloader<string, string> dataDownloader = new CachingDataDownloader<string, string>(
            new SlowDataDownloader(),
            new CachingManager<string, string>());
        Console.WriteLine(dataDownloader.DownloadData("id1"));
        Console.WriteLine(dataDownloader.DownloadData("id2"));
        Console.WriteLine(dataDownloader.DownloadData("id3"));
        Console.WriteLine(dataDownloader.DownloadData("id1"));
        Console.WriteLine(dataDownloader.DownloadData("id3"));
        Console.WriteLine(dataDownloader.DownloadData("id1"));
        Console.WriteLine(dataDownloader.DownloadData("id2"));

        IDataDownloader<int, DateTime> dataDownloader2 = new CachingDataDownloader<int, DateTime>(
            new SlowDateTimeDownloader(),
            new CachingManager<int, DateTime>());
        Console.WriteLine(dataDownloader2.DownloadData(1));
        Console.WriteLine(dataDownloader2.DownloadData(2));
        Console.WriteLine(dataDownloader2.DownloadData(3));
        Console.WriteLine(dataDownloader2.DownloadData(1));
        Console.WriteLine(dataDownloader2.DownloadData(2));
        Console.WriteLine(dataDownloader2.DownloadData(3));
        Console.WriteLine(dataDownloader2.DownloadData(1));
        Console.WriteLine(dataDownloader2.DownloadData(2));
        Console.WriteLine(dataDownloader2.DownloadData(3));

    }
}
