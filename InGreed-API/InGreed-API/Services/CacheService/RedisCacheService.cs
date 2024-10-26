using Newtonsoft.Json;
using StackExchange.Redis;

namespace InGreed_API.Services.CacheService.cs
{
    public class RedisCacheService : ICacheService
    {
        private ConnectionMultiplexer redis;
        private IDatabase cache;

        public RedisCacheService(string redisServerName)
        {
            try
            {
                redis = ConnectionMultiplexer.Connect(redisServerName);
                cache = redis.GetDatabase();
            }
            catch
            {
                Console.WriteLine("Redis connection failed");
            }
        }

        public async Task<bool> CheckIfDataExists(string key)
        {
            if (cache == null)
                return false;

            var data = await cache.StringGetAsync(key);
            return data.HasValue;
        }

        public async Task<T> GetData<T>(string key)
        {
            if (cache != null && await CheckIfDataExists(key))
            {
                string cachedData = await cache.StringGetAsync(key);

                if (!string.IsNullOrEmpty(cachedData))
                    return JsonConvert.DeserializeObject<T>(cachedData);
            }

            return default(T);
        }

        public async Task SetData<T>(string key, T data)
        {
            if (cache == null)
                return;

            string serializedData = JsonConvert.SerializeObject(data);
            await cache.StringSetAsync(key, serializedData, TimeSpan.FromHours(1));
        }
    }
}
