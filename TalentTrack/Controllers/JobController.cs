using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace TalentTrack.Controllers;

[Authorize]
[Route("api/v1/[controller]")]
[ApiController]
public class JobController : ControllerBase
{
    private IJobService _jobService;

    public JobController(IJobService jobService)
    {
        this._jobService = jobService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var jobs = _jobService.GetAll();
        return Ok(jobs);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var job = _jobService.GetById(id);
        if (job == null)
            return NotFound();

        return Ok(job);
    }


    [HttpPost]
    public IActionResult Create([FromBody] Job  job)
    {
        string created = _jobService.Create(job);
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
