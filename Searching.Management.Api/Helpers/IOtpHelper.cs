namespace Searching.Management.Api.Helpers;

public interface IOtpHelper
{
    public  Task<string> GetSecreteKey();
    public  byte[] EncryptOtp(string otp);
    public  string DecryptOtp(byte[] otp);
}