using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Threading.Tasks;

namespace TalentTrack.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public class CandidateController : ControllerBase
{
    private ICandidateService _candidateService;
    private readonly IRabbitPublisher _rabbitMQ;

    public CandidateController(ICandidateService candidateService, IRabbitPublisher rabbitMQ)
    {
        this._candidateService = candidateService;
        this._rabbitMQ = rabbitMQ;
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
    public async Task<IActionResult> Create([FromBody] Candidate candidate)
    {
        string created = _candidateService.Create(candidate);

        string result = await _rabbitMQ.PublishCandidateCreated(candidate, $"Candidate.Created");

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
