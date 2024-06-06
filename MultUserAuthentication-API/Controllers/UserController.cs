using Application.DTO.User;
using Application.Interfaces;
using Domain.Enum;
using Microsoft.AspNetCore.Mvc;
namespace MultUsersAuthentication_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerDto)
        {
            var result = await _userService.UserRegister(registerDto);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] AccountConfirmationDto confirmationDto)
        {
            var result = await _userService.ResetPassword(confirmationDto);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("register-role")]
        public async Task<IActionResult> RegisterRole([FromQuery] string userEmail, [FromQuery] RolesEnum role)
        {
            await _userService.RegisterRole(userEmail, role);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var user = await _userService.GetByEmail(email);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpGet("info/{userId}")]
        public async Task<IActionResult> GetUserInformation(Guid userId)
        {
            var result = await _userService.GetUserInformation(userId);
            return Ok(result);
        }

        [HttpGet("password-confirmation/{userId}")]
        public async Task<IActionResult> GetPasswordConfirmation(string userId)
        {
            var result = await _userService.GetPasswordConfirmation(userId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }

}
