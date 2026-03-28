using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;

public class FakeServiceBusPublisher : IServiceBusPublisher
{
    public async Task<string> SendMessageAsync(string queueName, object payload)
    {
        // do nothing
        return "ok";
    }
}