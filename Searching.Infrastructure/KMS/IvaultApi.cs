using RestEase;

namespace Searching.Infrastructure.KMS;

[BasePath("v1/")]
public interface IvaultApi
{
    [Get("auth/approle/login")]
    Task<AuthResponse> AppRoleLogin([Query] AuthAppRoleLoginRequest request);
    
    [Get("secret/data/{path}")]
    Task<Secrete<Dictionary<string, object>> >GetSecret(string path, [Header("X-Vault-Token")] string token);
    
}