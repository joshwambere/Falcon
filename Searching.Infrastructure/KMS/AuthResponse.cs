namespace Searching.Infrastructure.KMS;

public class AuthResponse
{
    public string Auth { get; set; }
    public string Lease_duration { get; set; }
    public string Renewable { get; set; }
    public string Lease_id { get; set; }
    public string Token { get; set; }
}