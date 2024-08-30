using AutoMapper;
using Business.DTOs.Role;
using Business.DTOs.User;
using Business.DTOs.UserRole;
using Domain.Models;

namespace Business.Mapper;

public class UserMapping:Profile
{
    public UserMapping()
    {
        CreateMap<User, UserGetDto>().ReverseMap();
        CreateMap<User, UserCreateDto>().ReverseMap();
        CreateMap<User, UserUpdateDto>().ReverseMap();

        CreateMap<UserRole, RoleGetDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Role.Id))
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName))
            .ReverseMap();

        CreateMap<UserRole, UserRoleCreateDto>().ReverseMap();
        CreateMap<UserRole, UserRoleUpdateDto>().ReverseMap();

    }
}
