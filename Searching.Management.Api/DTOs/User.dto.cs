namespace Searching.Management.Api.DTOs;

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class RegisterRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}

public class  LoginResponse
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