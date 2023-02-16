using RestEase;
using Searching.Infrastructure.KMS;
namespace Searching.Management.Api.KMSClient;

public class VaultClient
{
    private readonly IvaultApi _vaultApi;

    public VaultClient()
    {
        var client = new HttpClient
        {
            BaseAddress = new Uri("https://Falcon-private-vault-20aeacbf.0333e6cc.z1.hashicorp.cloud:8200/")
        };

        _vaultApi = RestClient.For<IvaultApi>(client);
    }

    public async Task<AuthResponse> AppRoleLogin(AuthAppRoleLoginRequest request)
    {
        return await _vaultApi.AppRoleLogin(request);
    }

    public async Task<Secrete<Dictionary<string, object>>> ReadSecret(string path,[Header("X-Vault-Token")] string token)
    {
        
        return await _vaultApi.GetSecret(path,token);
    }
}
