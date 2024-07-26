using Business.DTOs.Permission;
using Domain.Models;

namespace Business.GenericRepository.BaseServices;

public interface IPermissionService
{
    Task<IEnumerable<PermissionGetDto>>  GetList();
    
    Task<PermissionGetDto> GetItem(int id);

    Task<PermissionCreateDto> PostItem(PermissionCreateDto permissionCreateDto);

    Task<bool> PutItem(int id, PermissionUpdateDto permissionUpdateDto);

    Task<bool> DeleteItem(int id);
}