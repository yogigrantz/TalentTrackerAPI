using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace TalentTrack.Controllers;

[Authorize]
[Route("api/v1/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        this._clientService = clientService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var clients = _clientService.GetAll();
        return Ok(clients);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var client = _clientService.GetById(id);
        if (client == null)
            return NotFound();

        return Ok(client);
    }


    [HttpPost]
    public IActionResult Create([FromBody] Client client)
    {
        string created = _clientService.Create(client);
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
