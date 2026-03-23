using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using TalentTrack.Controllers;


namespace TalentTrackTests;

[TestClass]
public class AuthControllerTest
{
    private IConfiguration BuildFakeConfig()
    {
        var settings = new Dictionary<string, string?>
        {
            { "Jwt:Key", "super_secret_test_key_123456789012345" },
            { "Jwt:Issuer", "TestIssuer" },
            { "Jwt:Audience", "TestAudience" }
        };

        return new ConfigurationBuilder()
            .AddInMemoryCollection(settings)
            .Build();
    }

    [TestMethod]
    public void Login_WithValidCredentials_ReturnsOk()
    {
        IConfiguration config = BuildFakeConfig();
        var controller = new AuthController(config);

        var request = new TalentTrack.DTO.LoginRequest()
        {
            Username = "yogi",
            Password = "20002026!"
        };

        IActionResult result = controller.Login(request);

        Assert.IsInstanceOfType(result, typeof(OkObjectResult));

        Assert.IsNotNull(result);

        if (result is OkObjectResult okResult)
        {
            Assert.IsNotNull(okResult);

            var value = okResult.Value!;
            var tokenProperty = value.GetType().GetProperty("token");
            var token = tokenProperty?.GetValue(value)?.ToString();

            Assert.IsNotNull(token);
        }
        else
            Assert.Fail("Authentication did not return OkObjectResult");
    }


    [TestMethod]
    public void Login_WithInvalidCredentials_ReturnsUnauthorized()
    {
        IConfiguration config = BuildFakeConfig();
        var controller = new AuthController(config);

        var request = new TalentTrack.DTO.LoginRequest()
        {
            Username = "admin",
            Password = "wrong"
        };

        var result = controller.Login(request);

        Assert.IsInstanceOfType(result, typeof(UnauthorizedObjectResult));
    }

}
