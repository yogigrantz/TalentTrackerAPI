using Services;

namespace TalentTrackTests;

[TestClass]
public class CandidateServiceTest
{
    [TestMethod]
    public void GetCandidates_ReturnsCandidates()
    {
        var service = new CandidateService();

        var result = service.GetAll();

        Assert.IsNotNull(result);
        Assert.IsTrue(result.Count > 0);
    }
}
