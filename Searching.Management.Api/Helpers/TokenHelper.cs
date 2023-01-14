using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Searching.Domain.Entities;
using Searching.Management.Api.Attributes;

namespace Searching.Management.Api.Helpers;

[ScoppedService]
public  class TokenHelper : ITokenHelper
{
    private readonly AppSettings _appSettings;
    public  TokenHelper(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }
    public string GenerateToken(User user, int duration=59)
    {
        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.Jwt?.key!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim("userName", user.UserName),
            new Claim("Id", user.Id.ToString()),
        };
         var token = new JwtSecurityToken(
             _appSettings.Jwt!.issuer,
             _appSettings.Jwt.audience,
            claims,
            expires: duration != 59?DateTime.Now.AddMinutes(duration) : DateTime.Now.AddMinutes(59),
            signingCredentials: credentials);       
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    

    public string ActivationToken(User user)
    {
        return GenerateToken(user, 15);
    }
    
    public (bool,JwtSecurityToken) VerifyToken(string token)
    {
        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.Jwt?.key!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = credentials.Key,
            ValidateIssuer = true,
            ValidIssuer = _appSettings.Jwt!.issuer,
            ValidateAudience = true,
            ValidAudience = _appSettings.Jwt.audience,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
        try
        {
            tokenHandler.ValidateToken(token, validationParameters, out var _validatedToken);
            return (true, tokenHandler.ReadJwtToken(token));
        }
        catch
        {
            return (false,null);
        }
    }

}