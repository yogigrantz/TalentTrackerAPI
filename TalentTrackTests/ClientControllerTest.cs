using Microsoft.AspNetCore.Mvc;
using Services;
using TalentTrack.Controllers;

namespace TalentTrackTests;

[TestClass]
public class ClientControllerTest
{
    [TestMethod]
    public void GetClientFoundTest()
    {
        ClientController c = new ClientController(new ClientService());
        var result = c.GetById(1);
        Assert.IsTrue(result is OkObjectResult);
    }

    [TestMethod]
    public void GetClientNotFoundTest()
    {
        ClientController c = new ClientController(new ClientService());
        var result = c.GetById(-1);
        Assert.IsTrue(result is NotFoundResult);
    }

}
