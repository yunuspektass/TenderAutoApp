using AutoMapper;
using Business.DTOs.Permission;
using Domain.Models;

namespace Business.Mapper;

public class PermissionMapping:Profile
{
    public PermissionMapping()
    {
        CreateMap<Permission, PermissionCreateDto>().ReverseMap();
        CreateMap<Permission, PermissionGetDto>().ReverseMap();
        CreateMap<Permission, PermissionUpdateDto>().ReverseMap();
    }
}