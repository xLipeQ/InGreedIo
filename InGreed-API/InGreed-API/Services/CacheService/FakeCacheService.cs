using InGreed_API.Services.CacheService.cs;
using Newtonsoft.Json;
using System.Collections.Concurrent;

namespace InGreed_API.Services.CacheService
{
    public class FakeCacheService : ICacheService
    {
        private static ConcurrentDictionary<string, string> cache = new ConcurrentDictionary<string, string>();

        public async Task<bool> CheckIfDataExists(string key)
        {
            return cache.ContainsKey(key);
        }

        public async Task<T> GetData<T>(string key)
        {
            if (await CheckIfDataExists(key))
            {
                string cachedData = cache.GetValueOrDefault(key);

                if (!string.IsNullOrEmpty(cachedData))
                    return JsonConvert.DeserializeObject<T>(cachedData);
            }

            return default(T);
        }

        public async Task SetData<T>(string key, T data)
        {
            string serializedData = JsonConvert.SerializeObject(data);
            cache[key] = serializedData;
        }
    }
}
