using AutoMapper;
using Business.DTOs.Notification;
using Business.GenericRepository.BaseServices;
using Business.GenericRepository.ConcRep;
using Core.Services.ServiceClasses;
using Domain.Models;

namespace Business.GenericRepository.ConcManager;

public class NotificationManager:INotificationService
{
    private readonly NotificationRepository _notificationRepository;
    private readonly IMapper _mapper;
    private readonly IMailService _mailService;

    public NotificationManager(NotificationRepository notificationRepository , IMapper mapper , IMailService mailService)
    {
        _notificationRepository = notificationRepository;
        _mapper = mapper;
        _mailService = mailService;
    }
    
    public async Task<IEnumerable<NotificationGetDto>> GetList()
    {
        var notifications = await _notificationRepository.GetItems();

        return _mapper.Map<IEnumerable<NotificationGetDto>>(notifications);
    }

    public async Task<NotificationGetDto> GetItem(int id)
    {
        var notification = await _notificationRepository.GetItem(id);

        return _mapper.Map<NotificationGetDto>(notification);
    }

    public async Task<NotificationCreateDto> PostItem(NotificationCreateDto notificationCreateDto)
    {
        var notification = _mapper.Map<Notification>(notificationCreateDto);

        await _notificationRepository.Add(notification);

        await _mailService.SendEmailAsync("test@gmail.com", "Yeni Bildirim Eklendi",
            notification.Message);

        return _mapper.Map<NotificationCreateDto>(notification);
    }

    public async Task<bool> PutItem(int id, NotificationUpdateDto notificationUpdateDto)
    {
        var existingNotification = await _notificationRepository.GetItem(id);

        if (existingNotification == null)
        {
            return false;
        }

        _mapper.Map(notificationUpdateDto, existingNotification);
        
        await _notificationRepository.Update(existingNotification);

        await _mailService.SendEmailAsync("test@gmail.com", "Bildirim Güncellendi",
            id + " Numaralı bildirim güncellenmiştir.");

        return true;
    }

    public async Task<bool> DeleteItem(int id)
    {
        var existingNotification = await _notificationRepository.Find(id);

        if (existingNotification == null)
        {
            return false;
        }

        await _notificationRepository.Delete(existingNotification);

        await _mailService.SendEmailAsync("test@gmail.com", "Bildirim Silindi"
            , id + " Numaralı bildirim silinmiştir.");

        return true;

    }
}