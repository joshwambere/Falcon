using System.ComponentModel.DataAnnotations;

namespace Searching.Management.Api.DTOs;

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class RegisterDto
{
    [Required] public string Username { get; set; }
    [Required] [MinLength(6)] public string Password { get; set; }
    [Required] [EmailAddress] public string Email { get; set; }
    [Required] [Phone] public string Phone { get; set; }
}

public class LoginResponse
{
    public string Token { get; set; }
}

public class RegisterResponse
{
    public string message { get; set; }
    public bool success { get; set; }
}

public class LogoutResponse
{
    public string message { get; set; }
}

public class VerifyResponse
{
    public string message { get; set; }
    public bool success { get; set; }
}

public class VerifyRequest
{
    public string OTP { get; set; }
}

public class OtpDto
{
    [Required]
    [MaxLength(4)]
    [MinLength(4)]
    public string OTPCode { get; set; }
}