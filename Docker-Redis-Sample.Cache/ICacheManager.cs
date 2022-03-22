using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docker_Redis_Sample.Cache
{
    public interface ICacheManager
    {
        T Get<T>(string key) where T : class;
        void Set<T>(string key, T value, TimeSpan time) where T : class;
        bool IsSet(string key);
        void Clear(string key);
    }
}
