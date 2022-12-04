using Microsoft.AspNetCore.Mvc;
using OpenTelemetry.Trace;
using Searching.Infrastructure.Exceptions;
using Searching.Management.Api.DTOs;
using Searching.Management.Api.Services;

namespace Searching.Management.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly  UserService _userService;
    private ILogger<UsersController> _logger;


    public UsersController(UserService userService, ILogger<UsersController> logger)
    {
        _userService = userService;
        _logger = logger;
    }
    
    
    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
    {
        var result = await _userService.LoginAsync(request);
        return Ok(result);
    }
    
    [HttpPost("register")]
    public async Task<ActionResult<RegisterResponse>> Register([FromBody] RegisterDto userDto)
    {
        throw new DomainNotFoundException("resources forbidden");
        var result = await _userService.RegisterAsync(userDto);
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