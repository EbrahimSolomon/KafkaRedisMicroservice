using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace MessageConsumerService.Services;

public class KafkaConsumerService : BackgroundService
{
    private readonly RedisCacheService _redisService;
    private readonly IConsumer<string, string> _consumer;

    public KafkaConsumerService(RedisCacheService redisService, IConfiguration config)
    {
        _redisService = redisService;
        var consumerConfig = new ConsumerConfig
        {
            BootstrapServers = config["Kafka:BootstrapServers"],
            GroupId = config["Kafka:GroupId"],
            AutoOffsetReset = AutoOffsetReset.Earliest
        };
        _consumer = new ConsumerBuilder<string, string>(consumerConfig).Build();
        _consumer.Subscribe(config["Kafka:Topic"]);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var result = _consumer.Consume(stoppingToken);
            await _redisService.SetMessageAsync(result.Message.Key, result.Message.Value);
        }
    }
}
