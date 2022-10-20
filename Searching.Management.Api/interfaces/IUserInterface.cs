using Searching.Management.Api.DTOs;

namespace Searching.Management.Api.interfaces;

public interface IUserInterface
{
    public Task<LoginResponse> LoginAsync(LoginRequest request);

    public Task<RegisterResponse> RegisterAsync(RegisterRequest request);


    public Task<LogoutResponse> LogoutAsync();


    public Task<VerifyResponse> VerifyAsync(VerifyRequest request);


}