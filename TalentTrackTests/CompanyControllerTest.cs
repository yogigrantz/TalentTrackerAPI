using Microsoft.AspNetCore.Mvc;
using Services;
using TalentTrack.Controllers;

namespace TalentTrackTests;

[TestClass]
public class CompanyControllerTest
{
    [TestMethod]
    public void GetCompanyFoundTest()
    {
        CompanyController c = new CompanyController(new CompanyService());
        var result = c.GetById(1);
        Assert.IsTrue(result is OkObjectResult);
    }

    [TestMethod]
    public void GetCompanyNotFoundTest()
    {
        CompanyController c = new CompanyController(new CompanyService());
        var result = c.GetById(-1);
        Assert.IsTrue(result is NotFoundResult);
    }

}
