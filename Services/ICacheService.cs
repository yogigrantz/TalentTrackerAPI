using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace Services
{
    public interface ICacheService
    {
        Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> factory, TimeSpan? absoluteExpiration = null, TimeSpan? slidingExpiration = null, CacheItemPriority priority = CacheItemPriority.Normal);
    }
}