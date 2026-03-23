using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace TalentTrack.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public class CompanyController : ControllerBase
{
    private ICompanyService _companyService;

    public CompanyController(ICompanyService companySvc)
    {
        this._companyService = companySvc;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var companies = _companyService.GetAll();
        return Ok(companies);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var company = _companyService.GetById(id);
        if (company == null)
            return NotFound();

        return Ok(company);
    }


    [HttpPost]
    public IActionResult Create([FromBody] Company company)
    {
        string created = _companyService.Create(company);
        return Ok(created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return Ok();
    }


}
