using System.Security.Cryptography;

namespace Searching.Domain.Otp;

public static class Otps
{
    public static string  GenerateOtp()
    {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] randomNumber = new byte[4];
        rng.GetBytes(randomNumber);

        // Generate the OTP
        int otp = Math.Abs(BitConverter.ToInt32(randomNumber, 0)) % 1000000;
        return otp.ToString("D6");
    }
    
}