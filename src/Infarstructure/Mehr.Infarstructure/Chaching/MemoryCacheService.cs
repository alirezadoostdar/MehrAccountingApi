using Mehr.Application.Common.Contracts;
using Microsoft.Extensions.Caching.Memory;

namespace Mehr.Infarstructure.Chaching;

public class MemoryCacheService : ICacheService
{
    private readonly IMemoryCache _cache;

    public MemoryCacheService(IMemoryCache cache)
    {
        _cache = cache;
    }

    public Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken)
    {
        _cache.TryGetValue(key, out T? value);
        return Task.FromResult(value);
    }

    public async Task<T> GetOrCreateAsync<T>(
        string key, 
        Func<CancellationToken, Task<T>> factory, 
        TimeSpan? absoluteExpirationRelativeToNow = null, 
        TimeSpan? slidingExpiration = null, 
        CancellationToken cancellationToken = default)
    {
        if(! _cache.TryGetValue(key,out T? value))
        {
            value = await factory(cancellationToken);

            var options = new MemoryCacheEntryOptions();

            if(absoluteExpirationRelativeToNow.HasValue)
                options.AbsoluteExpirationRelativeToNow = absoluteExpirationRelativeToNow.Value;

            if(slidingExpiration.HasValue)
                options.SlidingExpiration = slidingExpiration.Value;

            _cache.Set(key, value, options);
        }

        return value!;
    }

    public Task RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task RemoveByPrefixAsync(string key, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<T> SetAsync<T>(string key, T value, TimeSpan? absoluteExpirationRelativeToNow = null, TimeSpan? slidingExpiration = null, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
