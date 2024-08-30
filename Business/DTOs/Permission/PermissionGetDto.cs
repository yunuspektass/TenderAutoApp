using Business.DTOs.RolePermission;

namespace Business.DTOs.Permission;

public class PermissionGetDto
{
    public int Id { get; set; }
    public string PermissionName { get; set; }
    public ICollection<RolePermissionGetDto> RolePermissions { get; set; }
}