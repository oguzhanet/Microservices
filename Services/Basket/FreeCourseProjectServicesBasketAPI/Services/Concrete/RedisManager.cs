using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;

namespace FreeCourseProjectServicesBasketAPI.Services.Concrete
{
    public class RedisManager 
    {
        private readonly string _host;
        private readonly int _port;
        private ConnectionMultiplexer _connectionMultiplexer;

        public RedisManager(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");

        public IDatabase GetDb(int db=1)=>_connectionMultiplexer.GetDatabase(db);

        public List<RedisKey> GetKeys() => _connectionMultiplexer.GetServer($"{_host}:{_port}").Keys(1).ToList();
    }
}
