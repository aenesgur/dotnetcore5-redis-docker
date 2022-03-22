using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docker_Redis_Sample.Cache.Redis
{
    public class RedisServer
    {
        private ConnectionMultiplexer _connectionMultiplexer;
        private IDatabase _database;
        private int _currentDb = 0;
        public RedisServer(IConfiguration configuration)
        {
            _connectionMultiplexer = ConnectionMultiplexer.Connect(configuration.GetSection("RedisSettings:RedisConnectionString").Value);
            _database = _connectionMultiplexer.GetDatabase(_currentDb);
        }

        public IDatabase Database => _database;
    }
}
