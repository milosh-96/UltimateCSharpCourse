namespace CustomCache.Data;

public interface IDataDownloader<TKey, TValue>
{
    TValue DownloadData(TKey resourceId);
}
