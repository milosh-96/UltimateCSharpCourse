using CustomCache.Caching;

namespace CustomCache.Data;
public class SlowDateTimeDownloader : IDataDownloader<int, DateTime>
{
    private readonly ICachingManager<int, DateTime> cachingManager;

    public SlowDateTimeDownloader(ICachingManager<int, DateTime> cachingManager)
    {
        this.cachingManager = cachingManager;
    }

    public DateTime DownloadData(int resourceId)
    {
        if (cachingManager.Has(resourceId))
        {
            return cachingManager.Get(resourceId);
        }

        //let's imagine this method downloads real data,
        //and it does it slowly
        Thread.Sleep(2000);

        //cache here
        DateTime data = DateTime.Now;
        cachingManager.Add(resourceId, data);
        return data;
    }
}
