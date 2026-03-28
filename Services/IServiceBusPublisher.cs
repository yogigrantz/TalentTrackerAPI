using System.Threading.Tasks;

public interface IServiceBusPublisher
{
    Task<string> SendMessageAsync(string queueName, object payload);
}