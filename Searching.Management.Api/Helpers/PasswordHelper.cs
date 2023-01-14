namespace Searching.Management.Api.Helpers;


public static class PasswordHelper
{
    public static string HashPassword(string password)
    { 
        var salt = BCrypt.Net.BCrypt.GenerateSalt(12);
        return BCrypt.Net.BCrypt.HashPassword(password, salt);
    }
    
    public static bool Verify(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}