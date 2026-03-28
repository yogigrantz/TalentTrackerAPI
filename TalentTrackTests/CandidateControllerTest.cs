using Microsoft.AspNetCore.Mvc;
using Services;
using TalentTrack.Controllers;

namespace TalentTrackTests;

[TestClass]
public class CandidateControllerTest
{
    [TestMethod]
    public void GetCandidateFoundTest()
    {
        CandidateController c = new CandidateController(new CandidateService(), new FakeRabbitPublisher());
        var result = c.GetById(1);
        Assert.IsTrue(result is OkObjectResult);
    }

    [TestMethod]
    public void GetCandidateNotFoundTest()
    {
        CandidateController c = new CandidateController(new CandidateService(), new FakeRabbitPublisher());
        var result = c.GetById(-1);
        Assert.IsTrue(result is NotFoundResult);
    }

}
