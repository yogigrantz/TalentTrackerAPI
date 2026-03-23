using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Linq;
using TalentTrack.DTO;

namespace TalentTrack.Controllers;

[Authorize]
[Route("api/v1/[controller]")]
[ApiController]
public class DashboardController : ControllerBase
{
    private readonly ICandidateService _cand;
    private readonly ICompanyService _comp;
    private readonly IClientService _client;
    private readonly IJobService _job;
    private readonly IPlacementService _place;

    public DashboardController(ICandidateService cand, ICompanyService comp, IClientService client, IJobService job, IPlacementService place)
    {
        this._cand = cand;
        this._comp = comp;
        this._client = client;
        this._job = job;
        this._place = place;
    }

    [HttpGet]
    public IActionResult GetCounts()
    {

        CountsDTO counts = new CountsDTO()
        {
            Candidates = _cand.GetAll().Count(),
            Companies = _comp.GetAll().Count(),
            Clients = _client.GetAll().Count(),
            Jobs = _job.GetAll().Count(),
            Placements = _place.GetAll().Count()
        };

        return Ok(counts);
    }
}
