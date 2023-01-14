namespace Searching.Management.Api.Services;

public interface IMailService
{
    public Task SendMail(string to, string subject, string body);
}