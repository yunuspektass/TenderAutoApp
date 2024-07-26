namespace Business.DTOs.Notification;

public class NotificationUpdateDto
{
    public int Id { get; set; }
    public string Message { get; set; }
    public int CompanyUserId { get; set; }
    public int AdminId { get; set; }
    public int TenderResponsibleId { get; set; }
}

