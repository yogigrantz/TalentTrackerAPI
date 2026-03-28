using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Services;
using System.Threading.Tasks;
using TalentTrack.Controllers;
using TalentTrack.DTO;

namespace TalentTrackTests;

[TestClass]
public class RegistrationControllerTest
{
    [TestMethod]
    public async Task RegisterTest()
    {
        var fakeSb = new FakeServiceBusPublisher();

        var controller = new RegistrationController(fakeSb);

        var request = new RegisterRequestDTO
        {
            UserName = "UnitTester",
            Password = "MySecretPassword",
            Email = "MSTest@tester.com"
        };

        var result = await controller.Register(request);

        var okResult = result as OkObjectResult;
        var value = okResult.Value;
        var messageProp = value.GetType().GetProperty("message");
        var userIdProp = value.GetType().GetProperty("userId");

        var message = messageProp?.GetValue(value)?.ToString();
        var userId = (int)(userIdProp?.GetValue(value) ?? 0);

        Assert.AreEqual("User registered successfully", message);
        Assert.IsTrue(userId > 0);
    }
}
