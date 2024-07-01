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
    [Route("CreateAdmin")]
    public IActionResult CreateAdmin([FromBody] AdminDto adminDto)
    {
        var result = _adminService.CreateAdmin(adminDto);
        if (!result.Success)
        {
            return BadRequest(result?.Message);
        }
        return Ok(result.Data);
    }

    [HttpGet]
    [Route("GetAdminById/{id}")]
    public IActionResult GetAdminById(Guid id)
    {
        var result = _adminService.GetAdminById(id);
        if (!result.Success)
        {
            return NotFound(result?.Message);
        }
        return Ok(result.Data);
    }

    [HttpGet]
    [Route("GetAdmins")]
    public IActionResult GetAdmins()
    {
        var result = _adminService.GetAdmin();
        if (!result.Success)
        {
            return NotFound(result?.Message);
        }
        return Ok(result.Data);
    }
}
