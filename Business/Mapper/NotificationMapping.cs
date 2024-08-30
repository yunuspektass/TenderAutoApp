using AutoMapper;
using Business.DTOs.Notification;
using Domain.Models;

namespace Business.Mapper;

public class NotificationMapping:Profile
{
    public NotificationMapping()
    {
        CreateMap<Notification, NotificationCreateDto>().ReverseMap();
        CreateMap<Notification, NotificationUpdateDto>().ReverseMap();
        CreateMap<Notification, NotificationGetDto>().ReverseMap();
    }
    
}