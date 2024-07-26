using Business.DTOs.Notification;

namespace Business.GenericRepository.BaseServices;

public interface INotificationService
{
    Task<IEnumerable<NotificationGetDto>> GetList();
    Task<NotificationGetDto> GetItem(int id);
    Task<NotificationCreateDto> PostItem(NotificationCreateDto notificationCreateDto);
    Task<bool> PutItem(int id, NotificationUpdateDto notificationUpdateDto);
    Task<bool> DeleteItem(int id);
}