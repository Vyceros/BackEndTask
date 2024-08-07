using BackEndTask.Application.JwtSettings;
using BackEndTask.Application.UserService.DTOs;
using BackEndTask.Application.UserServices;
using BackEndTask.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IJwtService _jwtTokenService;
    private readonly IUserServices _userService;

    public AuthController(IJwtService jwtTokenService, IUserServices userService)
    {
        _jwtTokenService = jwtTokenService;
        _userService = userService;
    }
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllusersAsync();
        return Ok(users);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserAuthDTO userAuthDto)
    {
        if (userAuthDto == null || string.IsNullOrEmpty(userAuthDto.UserName) || string.IsNullOrEmpty(userAuthDto.Password))
        {
            return BadRequest("Invalid user data.");
        }

        var user = await _userService.GetUserByUsernameAsync(userAuthDto.UserName);
        if (user == null || user.PasswordHash != userAuthDto.Password)
        {
            return Unauthorized();
        }

        var token = _jwtTokenService.GenerateToken(userAuthDto);
        return Ok(new { Token = token });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserAuthDTO userAuthDto)
    {
        if (userAuthDto == null || string.IsNullOrEmpty(userAuthDto.UserName) || string.IsNullOrEmpty(userAuthDto.Password))
        {
            return BadRequest("Invalid user data.");
        }

        var result = await _userService.RegisterUserAsync(userAuthDto);
        if (!result)
        {
            return BadRequest("User already exists or there was an error registering the user.");
        }

        return Ok("User registered successfully.");
    }
}
