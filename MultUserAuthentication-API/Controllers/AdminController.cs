
using Application.DTO.Admin;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MultUsersAuthentication_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpPost]
    [Route("CreateManager")]
    public IActionResult CreateManager([FromBody] AdminDto managerDto)
    {
        var result = _adminService.CreateManager(managerDto);
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
        var result = _adminService.GetManagerById(id);
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
        var result = _adminService.GetManager();
        if (!result.Success)
        {
            return NotFound(result?.Message);
        }
        return Ok(result.Data);
    }
}
