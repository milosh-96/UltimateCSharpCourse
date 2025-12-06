using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCache.Caching;
public interface ICachingManager<TKey, TValue>
{
    void Add(TKey key, TValue data);
    TValue Get(TKey key);
    bool Has(TKey key);

    void Remove(TKey key);
}
