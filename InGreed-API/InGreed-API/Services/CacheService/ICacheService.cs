namespace InGreed_API.Services.CacheService.cs
{
    public interface ICacheService
    {
        Task<bool> CheckIfDataExists(string key);
        Task<T> GetData<T>(string key);
        Task SetData<T>(string key, T data); 
    }
}
