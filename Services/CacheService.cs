using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace Services;

public class CacheService : ICacheService
{
    private readonly IMemoryCache _cache;

    public CacheService(IMemoryCache cache)
    {
        _cache = cache;
    }

    /* Sample usage of Cache with DBContext - retrieve from cache or from db with sliding expiration:
     * 
     *  User curUser = await _cacheService.GetOrCreateAsync($"user_{AppParameters.UserId}",
                            async () => await _dbContext.Users.AsNoTracking()
                                                .SingleAsync(x => x.Id == AppParameters.UserId),
                            absoluteExpiration: TimeSpan.FromMinutes(10),
                            slidingExpiration: TimeSpan.FromMinutes(3));

       !!! To remove cache whenever the entity us updated, execute this:

                _cache.Remove(key);
     * 
     */
    public async Task<T> GetOrCreateAsync<T>(
        string key,
        Func<Task<T>> factory,
        TimeSpan? absoluteExpiration = null,
        TimeSpan? slidingExpiration = null,
        CacheItemPriority priority = CacheItemPriority.Normal)
    {
        return await _cache.GetOrCreateAsync(key, async entry =>
        {
            if (absoluteExpiration.HasValue)
                entry.AbsoluteExpirationRelativeToNow = absoluteExpiration;

            if (slidingExpiration.HasValue)
                entry.SlidingExpiration = slidingExpiration;

            entry.Priority = priority;

            return await factory();
        });
    }
}