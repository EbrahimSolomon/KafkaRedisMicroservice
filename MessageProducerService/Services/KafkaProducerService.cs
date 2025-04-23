using Confluent.Kafka;
using Microsoft.Extensions.Configuration;

namespace MessageProducerService.Services;

public class KafkaProducerService
{
    private readonly IProducer<string, string> _producer;
    private readonly string _topic;

    public KafkaProducerService(IConfiguration config)
    {
        var producerConfig = new ProducerConfig
        {
            BootstrapServers = config["Kafka:BootstrapServers"]
        };
        _producer = new ProducerBuilder<string, string>(producerConfig).Build();
        _topic = config["Kafka:Topic"];
    }

    public async Task SendMessageAsync(string key, string message)
    {
        await _producer.ProduceAsync(_topic, new Message<string, string> { Key = key, Value = message });
    }
}
