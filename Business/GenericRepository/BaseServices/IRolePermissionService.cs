using Business.DTOs.RolePermission;

namespace Business.GenericRepository.BaseServices;

public interface IRolePermissionService
{
    Task<IEnumerable<RolePermissionGetDto>> GetList();

    Task<RolePermissionGetDto> GetItem(int id);

    Task<RolePermissionCreateDto> PostItem(RolePermissionCreateDto rolePermissionCreateDto);

    Task<bool> PutItem(int id, RolePermissionUpdateDto rolePermissionUpdateDto);

    Task<bool> DeleteItem(int id);
}