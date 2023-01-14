using Microsoft.Extensions.Options;
using Searching.Management.Api.Attributes;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Searching.Management.Api.Services;

[ScoppedService]
public class MailService: IMailService
{
    private readonly AppSettings _appSettings;
    
    public MailService(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }
    
    public async Task SendMail(string to, string subject,string template)
    {
        var sendgridKey = _appSettings.Sendgrid.key;
        var client = new SendGridClient(sendgridKey);
        var toEmail = new EmailAddress(to);
        var msg = new SendGridMessage
        {
            From = new EmailAddress(_appSettings.Sendgrid.senderEmail, _appSettings.Sendgrid.senderName),
            Subject = "Sending with Twilio SendGrid is Fun",
            PlainTextContent = "and easy to do anywhere, even with C#",
            HtmlContent =template,
            
        };
        msg.AddTo(toEmail);
        await  client.SendEmailAsync(msg).ConfigureAwait(false);
        

    }
}