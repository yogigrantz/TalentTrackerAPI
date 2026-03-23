using Data;
using Microsoft.AspNetCore.Mvc;
using Services;
using TalentTrack.Controllers;

namespace TalentTrackTests;

[TestClass]
public class PlacementControllerTest
{
    [TestMethod]
    public void FoundTest()
    {
        PlacementController c = new PlacementController(new PlacementService());
        var result = c.GetById(1);
        Assert.IsTrue(result is OkObjectResult);
    }

    [TestMethod]
    public void NotFoundTest()
    {
        PlacementController c = new PlacementController(new PlacementService());
        var result = c.GetById(-1);
        Assert.IsTrue(result is NotFoundResult);
    }

}
