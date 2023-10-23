using System.IdentityModel.Tokens.Jwt;
using Searching.Domain.Entities;

namespace Searching.Management.Api.Helpers;

public interface ITokenHelper
{
    public string GenerateToken(User user, int duration = 59);
    public string ActivationToken(User user);
    public (bool, JwtSecurityToken) VerifyToken(string token);
}