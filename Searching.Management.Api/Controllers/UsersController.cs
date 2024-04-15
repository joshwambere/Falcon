using Microsoft.AspNetCore.Mvc;
using Searching.Infrastructure.Utils;
using Searching.Management.Api.DTOs;
using Searching.Management.Api.Services;

namespace Searching.Management.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserService _userService;
    private ILogger<UsersController> _logger;

    public UsersController(UserService userService, ILogger<UsersController> logger,
        IHttpContextAccessor httpContextAccessor)
    {
        _userService = userService;
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
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
        var result = await _userService.RegisterWithOtp(userDto);
        return Ok(result);
    }

    [HttpGet("logout")]
    public async Task<ActionResult<LogoutResponse>> Logout()
    {
        var result = await _userService.LogoutAsync();
        return Ok(result);
    }


    [HttpGet("verify/{token}")]
    public async Task<ContentResult> Verify(string token)
    {
        try
        {
            await _userService.VerifyAsync(token);
            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = 200,
                Content = DomainTemplates.ActivatationSuccess()
            };
        }
        catch (Exception e)
        {
            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = 400,
                Content = DomainTemplates.FailedActivation(e.Message)
            };
        }
    }

    [HttpPost("verify")]
    public async Task<ActionResult<VerifyResponse>> VerifyOtp([FromBody] OtpDto verifyByOtpDto)
    {
        await _userService.VerifyOtpAsync(verifyByOtpDto);
        return Ok();
    }
}