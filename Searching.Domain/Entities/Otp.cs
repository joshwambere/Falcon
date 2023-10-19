using System.ComponentModel.DataAnnotations.Schema;
using Searching.Domain.Base;

namespace Searching.Domain.Entities;

[Table("Otp")]
public class Otp:BaseEntity
{
    public  string OtpCode { get; set; }
    public bool IsUsed { get; set; }
    public User User { get; set; }
}