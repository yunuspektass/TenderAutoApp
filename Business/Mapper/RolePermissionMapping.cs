using AutoMapper;
using Business.DTOs.RolePermission;
using Domain.Models;

namespace Business.Mapper;

public class RolePermissionMapping:Profile
{
    public RolePermissionMapping()
    {
        CreateMap<RolePermission, RolePermissionGetDto>().ReverseMap();
        CreateMap<RolePermission, RolePermissionCreateDto>().ReverseMap();
        CreateMap<RolePermission, RolePermissionCreateDto>().ReverseMap();
    }
}