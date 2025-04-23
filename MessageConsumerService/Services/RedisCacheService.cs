using StackExchange.Redis;
using Microsoft.Extensions.Configuration;

namespace MessageConsumerService.Services;

public class RedisCacheService
{
    private readonly IDatabase _cache;

    public RedisCacheService(IConfiguration config)
    {
        var redis = ConnectionMultiplexer.Connect(config["Redis:ConnectionString"]);
        _cache = redis.GetDatabase();
    }

    public async Task SetMessageAsync(string key, string value)
    {
        await _cache.StringSetAsync(key, value);
    }

    public async Task<string?> GetMessageAsync(string key)
    {
        var val = await _cache.StringGetAsync(key);
        return val.IsNullOrEmpty ? null : val.ToString();
    }
}
