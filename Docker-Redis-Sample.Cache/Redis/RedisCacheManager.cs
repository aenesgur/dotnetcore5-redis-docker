using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docker_Redis_Sample.Cache.Redis
{
    public class RedisCacheManager : ICacheManager
    {
        private RedisServer _redisServer;

        public RedisCacheManager(RedisServer redisServer)
        {
            _redisServer = redisServer;
        }

        public void Clear(string key)
        {
            _redisServer.Database.KeyDelete(key);
        }

        public T Get<T>(string key) where T : class
        {
            if (IsSet(key))
            {
                var result = _redisServer.Database.StringGet(key);
                return JsonConvert.DeserializeObject<T>(result);
            }
            return default;
        }

        public bool IsSet(string key)
        {
            return _redisServer.Database.KeyExists(key);
        }

        public void Set<T>(string key, T value, TimeSpan time) where T : class
        {
            _redisServer.Database.StringSet(key, JsonConvert.SerializeObject(value), time);
        }
    }
}
