using System.Net;
using System.Net.Mail;
using Core.Services.ServiceClasses;
using Core.Services.ServiceSettings;
using Microsoft.Extensions.Options;

namespace Core.Services.ServiceManager;

public class MailManager : IMailService
{
    private readonly MailSettings _mailSettings;

    public MailManager(IOptions<MailSettings> mailSettings)
    {
        _mailSettings = mailSettings.Value;
    }

    public Task SendEmailAsync(string email, string subject, string message)
    {
        var client = new SmtpClient(_mailSettings.Host, _mailSettings.Port)
        {
            EnableSsl = _mailSettings.EnableSsl,
            Credentials = new NetworkCredential(_mailSettings.UserName, _mailSettings.Password)
        };
        var mailMessage = new MailMessage
        {
            From = new MailAddress(_mailSettings.SenderEmail),
            Subject = subject,
            Body = message,
            IsBodyHtml = false
        };

        mailMessage.To.Add(new MailAddress(_mailSettings.SenderEmail));

        return client.SendMailAsync(mailMessage);
    }
}
