using AutoMapper;
using Business.DTOs.UserTender;
using Domain.Models;

namespace Business.Mapper;

public class UserTenderMapping:Profile
{
    public UserTenderMapping()
    {
        CreateMap<UserTender, UserTenderCreateDto>().ReverseMap();
        CreateMap<UserTender, UserTenderGetDto>().ReverseMap();
        CreateMap<UserTender, UserTenderUpdateDto>().ReverseMap();


    }

}
