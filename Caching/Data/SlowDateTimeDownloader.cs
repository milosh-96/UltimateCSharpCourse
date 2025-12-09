namespace CustomCache.Data;
public class SlowDateTimeDownloader : IDataDownloader<int, DateTime>
{
    public DateTime DownloadData(int resourceId)
    {
        //let's imagine this method downloads real data,
        //and it does it slowly
        Thread.Sleep(2000);
        //cache here
        DateTime data = DateTime.Now;
        return data;
    }
}
