using AutoMapper;
using Business.DTOs.Role;
using Domain.Models;

namespace Business.Mapper;

public class RoleMapping:Profile
{
    public RoleMapping()
    {
        CreateMap<Role, RoleCreateDto>().ReverseMap();
        CreateMap<Role, RoleGetDto>().ReverseMap();
        CreateMap<Role , RoleUpdateDto>();
    }
}