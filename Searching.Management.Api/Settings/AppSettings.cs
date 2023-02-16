namespace Searching.Management.Api;

public class AppSettings
{
    public Jwt? Jwt { get; init; }
    public Sendgrid? Sendgrid { get; init; }
    public AppUrls? AppUrls { get; init; }
    public OTPSettings OTPSettings { get; init; }
    public HashiCorp? HashiCorp { get; init; }

}

public class Jwt
{
    public string? key { get; init; }
    public string? issuer { get; init; }
    public string? audience { get; init; }
    
}

public class Sendgrid
{
    public string? key { get; init; }
    public string? senderEmail { get; init; }
    public string? senderName { get; init; }
}

public class AppUrls
{
    public string? client { get; init; }
    public string? clientActivateAccount { get; init; }
}

public class OTPSettings
{
    public string? secreteKey { get; init; }
   
}

public class HashiCorp
{
    public string VaultUrl { get; init; }
    public string VaultToken { get; init; }
    public string RoleId { get; init; }
    public string SecretId { get; init; }
}