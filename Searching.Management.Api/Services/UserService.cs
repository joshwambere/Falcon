using Searching.Management.Api.Attributes;
using Searching.Management.Api.DTOs;

namespace Searching.Management.Api.Services;

[ScoppedService]
public class UserService 
{

    public Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        return Task.FromResult(new LoginResponse
        {
            Token = "token"
        });
    }
    public Task<RegisterResponse> RegisterAsync(RegisterRequest request)
    {
        return Task.FromResult(new RegisterResponse
        {
            message = "Registration successful",
            success = true
        });
    }

    public Task<LogoutResponse> LogoutAsync()
    {
        return Task.FromResult(new LogoutResponse
        {
            message = "Logout successful",
        });
    }
    
    public Task<VerifyResponse> VerifyAsync(VerifyRequest request)
    {
        return Task.FromResult(new VerifyResponse
        {
            message = "Verification successful",
            success = true
        });
    }

}