using System.Threading.Tasks;

namespace Services
{
    public interface IRabbitPublisher
    {
        Task<string> PublishCandidateCreated<T>(T candidate, string queueName);
    }
}