using Searching.Domain.Base;

namespace Searching.Domain.Entities;

public class Otp:BaseEntity
{
    public  string OtpCode { get; set; }
    public bool IsUsed { get; set; }
    public string Id { get; set; }
    public User User { get; set; }
}