namespace Core.Services.ServiceSettings;

public class MailSettings
{
    public string Host { get; set; }

    public int Port { get; set; }
    public bool EnableSsl { get; set; }

    public string SenderName { get; set; }

    public string SenderEmail { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }
}
