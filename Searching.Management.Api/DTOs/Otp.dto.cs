namespace Searching.Management.Api.DTOs;

public class SavedResponse
{
    public string message { get; set; }
    public bool success { get; set; }
}

public class OTP
{
    public string otp { get; set; }
    public DateTime duration { get; set; }
}