using Microsoft.AspNetCore.Mvc;
using MessageConsumerService.Services;

[ApiController]
[Route("[controller]")]
public class ReadController : ControllerBase
{
    private readonly RedisCacheService _cache;

    public ReadController(RedisCacheService cache) => _cache = cache;

    [HttpGet("{key}")]
    public async Task<IActionResult> Get(string key)
    {
        var value = await _cache.GetMessageAsync(key);
        return value is null ? NotFound() : Ok(value);
    }
}
