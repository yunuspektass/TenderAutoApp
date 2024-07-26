namespace Core.Services.ServiceClasses;

public interface IMailService
{
    Task SendEmailAsync(string email, string subject, string message);
}