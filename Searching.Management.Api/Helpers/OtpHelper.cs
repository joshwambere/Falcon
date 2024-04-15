using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Searching.Infrastructure.Exceptions;
using Searching.Infrastructure.KMS;
using Searching.Management.Api.Attributes;
using Searching.Management.Api.KMSClient;

namespace Searching.Management.Api.Helpers;

[ScoppedService]
public class OtpHelper : IOtpHelper
{
    private static readonly int _keySize = 256;
    private static readonly int _blockSize = 128;
    private readonly AppSettings _appSettings;

    public OtpHelper(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }

    public async Task<string> GetSecreteKey()
    {
        var client = new VaultClient();
        var response = client.AppRoleLogin(new AuthAppRoleLoginRequest
        {
            RoleId = _appSettings.HashiCorp.RoleId,
            SecretId = _appSettings.HashiCorp.SecretId
        });

        if (response.IsCompleted)
        {
            var json = await response;
            var token = json.Token;

            return token;
        }

        throw new DomainInternalServerErrorException("HashiCorp Vault Error");
    }

    public byte[] EncryptOtp(string OTP)
    {
        var secreteKey = GetSecreteKey().Result;
        var client = new VaultClient();
        var keys = client.ReadSecret("/secrets/otp/sicrete", secreteKey).Result;
        var key = Encoding.UTF8.GetBytes("dfd");

        using (var aes = new AesCryptoServiceProvider())
        {
            aes.KeySize = _keySize;
            aes.BlockSize = _blockSize;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = key;
            aes.GenerateIV();

            using (var encryptor = aes.CreateEncryptor())
            {
                var OTPBytes = Encoding.UTF8.GetBytes(OTP);
                var encryptedOTP = encryptor.TransformFinalBlock(OTPBytes, 0, OTPBytes.Length);
                return encryptedOTP;
            }
        }
    }

    public string DecryptOtp(byte[] OTP)
    {
        var secreteKey = GetSecreteKey();
        var key = Encoding.UTF8.GetBytes(secreteKey.Result);

        using (var aes = new AesCryptoServiceProvider())
        {
            aes.KeySize = _keySize;
            aes.BlockSize = _blockSize;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = key;
            aes.GenerateIV();

            using (var decryptor = aes.CreateDecryptor())
            {
                var decryptedOTP = decryptor.TransformFinalBlock(OTP, 0, OTP.Length);
                return Encoding.UTF8.GetString(decryptedOTP);
            }
        }
    }
}