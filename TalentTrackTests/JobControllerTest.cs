using Microsoft.AspNetCore.Mvc;
using Services;
using TalentTrack.Controllers;

namespace TalentTrackTests;

[TestClass]
public class JobControllerTest
{
    [TestMethod]
    public void FoundTest()
    {
        JobController c = new JobController(new JobService());
        var result = c.GetById(1);
        Assert.IsTrue(result is OkObjectResult);
    }

    [TestMethod]
    public void NotFoundTest()
    {
        JobController c = new JobController(new JobService());
        var result = c.GetById(-1);
        Assert.IsTrue(result is NotFoundResult);
    }

}
