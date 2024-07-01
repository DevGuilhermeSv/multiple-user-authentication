using Microsoft.AspNetCore.Mvc;
using Application.DTO.Manager;
using Application.Interfaces;

namespace MultUsersAuthentication_API.Controllers;



[ApiController]
[Route("api/[controller]")]
public class ManagerController : ControllerBase
{
    private readonly IManagerService _managerService;

    public ManagerController(IManagerService managerService)
    {
        _managerService = managerService;
    }

    [HttpPost]
    [Route("CreateManager")]
    public IActionResult CreateManager([FromBody] ManagerDto managerDto)
    {
        var result = _managerService.CreateManager(managerDto);
        if (!result.Success)
        {
            return BadRequest(result?.Message);
        }
        return Ok(result.Data);
    }

    [HttpGet]
    [Route("GetManagerById/{id}")]
    public IActionResult GetManagerById(Guid id)
    {
        var result = _managerService.GetManagerById(id);
        if (!result.Success)
        {
            return NotFound(result?.Message);
        }
        return Ok(result.Data);
    }

    [HttpGet]
    [Route("GetManagers")]
    public IActionResult GetManagers()
    {
        var result = _managerService.GetManager();
        if (!result.Success)
        {
            return NotFound(result?.Message);
        }
        return Ok(result.Data);
    }
}
