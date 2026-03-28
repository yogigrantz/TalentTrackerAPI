using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class ServiceBusPublisher : IServiceBusPublisher
{
    private readonly ServiceBusClient _client;

    public ServiceBusPublisher(IConfiguration config)
    {
        _client = new ServiceBusClient(config["ServiceBus:ConnectionString"]);
    }

    public async Task<string> SendMessageAsync(string queueName, object payload)
    {
        try
        {
            var sender = _client.CreateSender(queueName);

            string json = JsonSerializer.Serialize(payload);

            var message = new ServiceBusMessage(Encoding.UTF8.GetBytes(json))
            {
                ContentType = "application/json"
            };

            await sender.SendMessageAsync(message);

            return json;
        }
        catch (System.Exception ex)
        {
            return ex.Message;
        }
    }
}