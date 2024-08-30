namespace Business.DTOs.RolePermission;

public class RolePermissionGetDto
{
    public int RoleId { get; set; }
    public string RoleName { get; set; }
    public int PermissionId { get; set; }
    public string PermissionName { get; set; }
}