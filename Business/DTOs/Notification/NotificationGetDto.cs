using Business.DTOs.User;

namespace Business.DTOs.Notification;

public class NotificationGetDto
{
    public int Id { get; set; }
    public string Message { get; set; }
    public int UserId { get; set; }
   public bool IsRead { get; set; }

}
