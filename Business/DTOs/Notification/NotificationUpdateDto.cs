namespace Business.DTOs.Notification;

public class NotificationUpdateDto
{
  public int Id { get; set; }
  public string Message { get; set; }
  public int UserId { get; set; }
  public bool IsRead { get; set; }

}


