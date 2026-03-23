using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace TalentTrack.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public class CandidateController : ControllerBase
{
    private ICandidateService _candidateService;

    public CandidateController(ICandidateService candidateService)
    {
        this._candidateService = candidateService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var candidates = _candidateService.GetAll();
        return Ok(candidates);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var candidate = _candidateService.GetById(id);
        if (candidate == null)
            return NotFound();

        return Ok(candidate);
    }


    [HttpPost]
    public IActionResult Create([FromBody] Candidate candidate)
    {
        string created = _candidateService.Create(candidate);
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
