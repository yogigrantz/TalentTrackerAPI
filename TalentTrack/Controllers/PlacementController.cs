using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace TalentTrack.Controllers;

[Authorize]
[Route("api/v1/[controller]")]
[ApiController]
public class PlacementController : ControllerBase
{
    private IPlacementService _placementService;

    public PlacementController(IPlacementService placementService)
    {
        this._placementService = placementService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var placements = _placementService.GetAll();
        return Ok(placements);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var placement = _placementService.GetById(id);
        if (placement == null)
            return NotFound();

        return Ok(placement);
    }


    [HttpPost]
    public IActionResult Create([FromBody] Placement placement)
    {
        string created = _placementService.Create(placement);
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
