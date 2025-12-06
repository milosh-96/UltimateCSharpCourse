namespace CustomCache.Caching;

public class CachingManager<TKey, TValue> : ICachingManager<TKey, TValue>
{
    private Dictionary<TKey, TValue> _data = new Dictionary<TKey, TValue>();

    public void Add(TKey key, TValue data)
    {
        _data.Add(key, data);
    }

    public TValue Get(TKey key) => _data.GetValueOrDefault(key);

    public bool Has(TKey key) => _data.ContainsKey(key);

    public void Remove(TKey key)
    {
        _data.Remove(key);
    }
}
