using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCache.Caching;
public interface ICachingManager
{
    void Add(string resourceId, string data);
    string Get(string resourceId);
    bool Has(string resourceId);
}
