using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCache.Caching;
public class CachingManager : ICachingManager
{
    private Dictionary<string, string> _data = new Dictionary<string, string>();

    public void Add(string key, string data)
    {
        _data.Add(key, data);
    }

    public string Get(string key) => _data.GetValueOrDefault(key);

    public bool Has(string key) => _data.ContainsKey(key);
}
