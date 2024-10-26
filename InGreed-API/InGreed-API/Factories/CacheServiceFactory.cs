using InGreed_API.Services.CacheService;
using InGreed_API.Services.CacheService.cs;

namespace InGreed_API.Factories
{
    public static class CacheServiceFactory
    {
        public static ICacheService GetFactory(IConfiguration configuration)
        {
            var fakeServices = configuration["FakeServices"].Split(";");

            if (!fakeServices.Contains("CacheService"))
                return new RedisCacheService(configuration["RedisServerName"]);
            else
                return new FakeCacheService();
        }
    }
}
