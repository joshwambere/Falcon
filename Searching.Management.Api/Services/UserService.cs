using Microsoft.Extensions.Options;
using Searching.Domain.Entities;
using Searching.Infrastructure.Data;
using Searching.Management.Api.Attributes;
using Searching.Management.Api.DTOs;
using Searching.Management.Api.Helpers;
using Searching.Infrastructure.Exceptions;
using Searching.Infrastructure.Utils;
using Searching.Domain.Otp;



namespace Searching.Management.Api.Services;

[ScoppedService]
public class UserService : BaseService
{

    private readonly ITokenHelper _tokenHelper;
    private readonly IMailService _mailService;
    private readonly AppSettings _appSettings;
    private readonly IOtpHelper _otpHelper;
    
    public UserService(IUnitOfWork _unitOfWork, ITokenHelper tokenHelper, IOtpHelper otpHelper, IMailService mailService, IOptions<AppSettings> appSettings) : base(_unitOfWork)
    {
        _tokenHelper = tokenHelper;
        _otpHelper = otpHelper;
        _mailService = mailService;
        _appSettings = appSettings.Value;
        
    }
    

    /*
     * Login user 🚀
     * @Param: LoginDTO
     * @Return: Token:string
     */
    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        var repository = UnitOfWork.AsyncRepository<User>();
        var user = await repository.GetAsync(x => x.Email == request.Username);
        
        if (user == null)
        {
            throw new DomainBadRequestException("Invalid username or password");
        }

        if (user.IsVerified == false)
        {
            throw new DomainBadRequestException("Account is not verified");
        }
        
        var passwordCheck = PasswordHelper.Verify(request.Password, user.Password);
        
        if (!passwordCheck)
        {
            throw new DomainBadRequestException("Invalid username or password");
        }
        
        var token  = _tokenHelper.GenerateToken(user);
        
        return await Task.FromResult(new LoginResponse
        {
            Token = token
        });
    }
    
    /*
     * Register new  user 🚀
     * @Param: RegisterDTO
     * @Return: RegisterResponse
     */
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
            newUser.Password = PasswordHelper.HashPassword(newUser.Password);
            var repository = UnitOfWork.AsyncRepository<User>();
            await repository.AddAsync(newUser);
            await UnitOfWork.SaveChangesAsync();
            var savedUser = await UnitOfWork.AsyncRepository<User>().GetAsync(x=>x.Id==newUser.Id);
            var domain = _appSettings.AppUrls!.clientActivateAccount;
            var token = _tokenHelper.ActivationToken(savedUser);
            var url = $"{domain}/{token}";

            if (Equals(savedUser,null))
            {
                return await Task.FromResult(new RegisterResponse
                {
                    message = "Something Went wrong",
                    success = true
                });
            }
            var template = EmailTemplateEngine.ActivationMail(savedUser.UserName, url);
            var send = _mailService.SendMail(savedUser.Email, "Account Activation", template);
            if (send == null)
            {
                throw  new DomainExternalServiceException("Error sending email");
            }
            return await Task.FromResult(new RegisterResponse
            {
                message = "User created successfully",
                success = true
            });

        }
        catch (Exception e)
        {
            throw new DomainInternalServerErrorException(e.Message);
        }
    }

    public async Task<RegisterResponse> RegisterWithOtp(RegisterDto request)
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
            newUser.Password = PasswordHelper.HashPassword(newUser.Password);
            var repository = UnitOfWork.AsyncRepository<User>();
            await repository.AddAsync(newUser);
            await UnitOfWork.SaveChangesAsync();
            var savedUser = await UnitOfWork.AsyncRepository<User>().GetAsync(x=>x.Id==newUser.Id);
            var otp = Otps.GenerateOtp();

            if (Equals(savedUser,null))
            {
                return await Task.FromResult(new RegisterResponse
                {
                    message = "Something Went wrong",
                    success = true
                });
            }
            var template = EmailTemplateEngine.OtpEmail(savedUser.UserName, otp);
            var send = _mailService.SendMail(savedUser.Email, "Account Activation", template);
            var otpRepository = UnitOfWork.AsyncRepository<Otp>();
            
            var otpEntity = new Otp
            {
                OtpCode = otp,
                User = savedUser,
                IsUsed = false,
                IsDeleted = false
            };
            
            await otpRepository.AddAsync(otpEntity);
            await UnitOfWork.SaveChangesAsync();
            
            if (send == null)
            {
                throw  new DomainExternalServiceException("Error sending email");
            }
            return await Task.FromResult(new RegisterResponse
            {
                message = "User created successfully",
                success = true
            });

        }
        catch (Exception e)
        {
            throw new DomainInternalServerErrorException(e.Message);
        }
    }

    public Task<LogoutResponse> LogoutAsync()
    {
        return Task.FromResult(new LogoutResponse
        {
            message = "Logout successful",
        });
    }
    
    public async Task<VerifyResponse> VerifyAsync(string token)
    {
        var (validity,userObject) = _tokenHelper.VerifyToken(token);
        if (!validity)
        {
            throw new DomainBadRequestException("Invalid tokens");
        }

        var userId = userObject.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;
        var user = await UnitOfWork.AsyncRepository<User>().GetAsync(x => x.Id == userId);
        if (user == null)
        {
            throw new DomainUnauthorizedException("Access denied");
        }

        if (user.IsVerified)
        {
            throw new DomainBadRequestException("Account already verified");
        }

        user.IsVerified = true;
        await UnitOfWork.AsyncRepository<User>().UpdateAsync(user);
        await UnitOfWork.SaveChangesAsync();

        return await Task.FromResult(new VerifyResponse
        {
            message = "Verification successful",
            success = true
        });
    }

    public async Task<VerifyResponse> VerifyOtpAsync(OtpDto otp)
    {
        return await Task.FromResult(new VerifyResponse
        {
            message = "Verification successful",
            success = true
        });
    }

}