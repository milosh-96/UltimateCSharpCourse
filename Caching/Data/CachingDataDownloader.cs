using CustomCache.Caching;
namespace CustomCache.Data;
public class CachingDataDownloader<TKey, TValue> : IDataDownloader<TKey, TValue>
{
    private readonly IDataDownloader<TKey, TValue> _dataDownloader;
    private readonly ICachingManager<TKey, TValue> _cachingManager;
    public CachingDataDownloader(IDataDownloader<TKey, TValue> dataDownloader, ICachingManager<TKey, TValue> cachingManager)
    {
        _dataDownloader = dataDownloader;
        _cachingManager = cachingManager;
    }

    public TValue DownloadData(TKey resourceId)
    {
        if(_cachingManager.Has(resourceId))
        {
            return _cachingManager.Get(resourceId);
        }
        TValue item = _dataDownloader.DownloadData(resourceId);
        _cachingManager.Add(resourceId, item);
        return _cachingManager.Get(resourceId);
    }
}
