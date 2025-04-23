using MessageProducerService.Services;
using Microsoft.AspNetCore.Mvc;

namespace MessageProducerService.Controllers;

[ApiController]
[Route("[controller]")]
public class MessageController : ControllerBase
{
    private readonly KafkaProducerService _producerService;

    public MessageController(KafkaProducerService producerService)
    {
        _producerService = producerService;
    }

    [HttpPost]
    public async Task<IActionResult> Send([FromQuery] string key, [FromBody] string message)
    {
        await _producerService.SendMessageAsync(key, message);
        return Ok("Message Sent");
    }
}
