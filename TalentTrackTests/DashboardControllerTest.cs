using Microsoft.AspNetCore.Mvc;
using Services;
using TalentTrack.Controllers;
using TalentTrack.DTO;

namespace TalentTrackTests;

[TestClass]
public class DashboardControllerTest
{

    [TestMethod]
    public void DashbordCountsTest()
    {
        var controller = new DashboardController(
             new CandidateService(),
             new CompanyService(),
             new ClientService(),
             new JobService(),
             new PlacementService()
         );

        var result = controller.GetCounts() as OkObjectResult;

        Assert.IsNotNull(result);

        var counts = result.Value as CountsDTO;

        Assert.IsNotNull(counts);
        Assert.IsTrue(counts.Candidates > 0);
    }
}
