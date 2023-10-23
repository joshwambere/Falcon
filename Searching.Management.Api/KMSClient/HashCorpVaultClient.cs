namespace Searching.Management.Api.KMSClient;

public class HashCorpVaultClient
{
    private readonly AppSettings _appSettings;
    private VaultClient _vaultClient;
    public HashCorpVaultClient(AppSettings appSettings, VaultClient vaultClient)
    {
        _appSettings = appSettings;
        _vaultClient = vaultClient;
    }

    protected async void getSecret(VaultClient vaultClient)
    {
        _vaultClient = vaultClient;
    }
}