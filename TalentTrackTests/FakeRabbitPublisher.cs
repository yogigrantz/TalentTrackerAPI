using Services;
using System.Threading.Tasks;

namespace TalentTrackTests;

public class FakeRabbitPublisher : IRabbitPublisher
{
    public Task<string> PublishCandidateCreated<T>(T candidate, string queueName)
    {
        return Task.FromResult("fake publish");
    }
}