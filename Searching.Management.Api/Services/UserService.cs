using System.Text.Json;
using Searching.Domain.Entities;
using Searching.Infrastructure.Data;
using Searching.Management.Api.Attributes;
using Searching.Management.Api.DTOs;
using Searching.Management.Api.interfaces;

namespace Searching.Management.Api.Services;

[ScoppedService]
public class UserService : BaseService
{

    public UserService(IUnitOfWork _unitOfWork) : base(_unitOfWork)
    {
    }
    

    public Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        return Task.FromResult(new LoginResponse
        {
            Token = "token"
        });
    }
    public async Task<RegisterResponse>  RegisterAsync(RegisterDto request)
    {
        var newUser = new User
        {
            UserName = request.Username,
            Password = request.Password,
            Email = request.Email,
            Phone = request.Phone
        };
        
        try
        {
            Console.WriteLine(JsonSerializer.Serialize(newUser));
            var repository = UnitOfWork.AsyncRepository<User>();
            await repository.AddAsync(newUser);
            await UnitOfWork.SaveChangesAsync();
            var saved = await UnitOfWork.AsyncRepository<User>().GetAsync(x=>x.Id==newUser.Id);
            if (saved != null)
            {
                Console.WriteLine(saved.Id);
                return await Task.FromResult(new RegisterResponse
                {
                    message = "User created successfully",
                    success = false
                });  
            }
            
            return await Task.FromResult(new RegisterResponse
            {
                message = "User not created",
                success = true
            });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }



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