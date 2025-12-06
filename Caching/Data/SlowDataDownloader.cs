using CustomCache.Caching;

namespace CustomCache.Data;
public class SlowDataDownloader : IDataDownloader
{
    private readonly ICachingManager cachingManager;

    public SlowDataDownloader(ICachingManager cachingManager)
    {
        this.cachingManager = cachingManager;
    }

    public string DownloadData(string resourceId)
    {
        if (cachingManager.Has(resourceId))
        {
            return cachingManager.Get(resourceId);
        }

        //let's imagine this method downloads real data,
        //and it does it slowly
        Thread.Sleep(2000);

        //cache here
        string data = $"Some data for {resourceId}";
        cachingManager.Add(resourceId, data);
        return data;
    }
}
