
using Application.DTO.Admin;
using Application.DTO.Client;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MultUsersAuthentication_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpPost]
    [Route("CreateClient")]
    public IActionResult CreateClient([FromBody] ClientDto clientDto)
    {
        var result = _clientService.CreateClient(clientDto);
        if (!result.Success)
        {
            return BadRequest(result?.Message);
        }
        return Ok(result.Data);
    }

    [HttpGet]
    [Route("GetClientById/{id}")]
    public IActionResult GetClientById(Guid id)
    {
        var result = _clientService.GetClientById(id);
        if (!result.Success)
        {
            return NotFound(result?.Message);
        }
        return Ok(result.Data);
    }

    [HttpGet]
    [Route("GetClient")]
    public IActionResult GetClients()
    {
        var result = _clientService.GetClient();
        if (!result.Success)
        {
            return NotFound(result?.Message);
        }
        return Ok(result.Data);
    }
}
