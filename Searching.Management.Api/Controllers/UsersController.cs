using Microsoft.AspNetCore.Mvc;
using Searching.Management.Api.DTOs;
using Searching.Management.Api.Services;

namespace Searching.Management.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly  UserService _userService;
    
    public UsersController(UserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
    {
        var result = await _userService.LoginAsync(request);
        return Ok(result);
    }
    
    [HttpPost("register")]
    public async Task<ActionResult<RegisterResponse>> Register([FromBody] RegisterRequest request)
    {
        var result = await _userService.RegisterAsync(request);
        return Ok(result);
    }
    
    [HttpGet("logout")]
    public async Task<ActionResult<LogoutResponse>> Logout()
    {
        var result = await _userService.LogoutAsync();
        return Ok(result);
    }
    
    [HttpPost("verify")]
    public async Task<ActionResult<VerifyResponse>> Verify([FromBody] VerifyRequest request)
    {
        var result = await _userService.VerifyAsync(request);
        return Ok(result);
    }
}