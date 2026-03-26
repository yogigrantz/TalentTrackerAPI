using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services;

public class RabbitPublisher : IRabbitPublisher
{

    private readonly ConnectionFactory _factory;
    private readonly ILogger<RabbitPublisher> _logger;
    private readonly IConfiguration _config;

    public RabbitPublisher(ILogger<RabbitPublisher> logger, IConfiguration config)
    {
        //_factory = new ConnectionFactory()
        //{
        //    HostName = _config["RabbitMQ:HostName"],
        //    UserName = _config["RabbitMQ:User"],
        //    Password = _config["RabbitMQ:Password"],
        //    VirtualHost = _config["RabbitMQ:VHost"],
        //    Port = int.Parse(_config["RabbitMQ:Port"]),
        //    Ssl = new SslOption
        //    {
        //        Enabled = true
        //    }
        //};
        _config = config; 
        _factory = new ConnectionFactory()
        {
            Uri = new Uri($"amqps://{_config["RabbitMQ:User"]}:{_config["RabbitMQ:Password"]}@{_config["RabbitMQ:HostName"]}/{_config["RabbitMQ:VHost"]}")
        };
        this._logger = logger;
        this._config = config;
    }

    public async Task<string> PublishCandidateCreated<T>(T candidate, string queueName)
    {
        string json = "";
        try
        {
            using var connection = await _factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(
                queue: queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            json = JsonSerializer.Serialize(candidate);
            byte[] body = Encoding.UTF8.GetBytes(json);

            await channel.BasicPublishAsync(exchange: "", routingKey: queueName, body: body);

            return $"📤 Queued: {json}";

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"RabbitMQ publish failed for queue {queueName}. Payload: {json}");
            return ex.Message;
        }
    }
}
