using Searching.Domain.Base;
using Searching.Domain.Enums;

namespace Searching.Domain.Entities;

public class User:BaseEntity
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string? status { get;set; } = Enum.GetName(typeof(AccountStatus), AccountStatus.ACTIVE);
    public bool IsVerified { get; set; } = false;
    public string? Roles { get; set; } = Enum.GetName(typeof(UserRoles), UserRoles.User);
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
}