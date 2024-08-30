using AutoMapper;
using Business.DTOs.UserRole;
using Domain.Models;

namespace Business.Mapper;

public class UserRoleMapping:Profile
{
    public UserRoleMapping()
    {
        CreateMap<UserRole, UserRoleGetDto>().ReverseMap();
        CreateMap<UserRole, UserRoleCreateDto>().ReverseMap();
        CreateMap<UserRole, UserRoleUpdateDto>().ReverseMap();
    }
}
