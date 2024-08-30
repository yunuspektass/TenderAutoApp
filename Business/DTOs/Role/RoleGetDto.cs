using Business.DTOs.RolePermission;
using Business.DTOs.UserRole;

namespace Business.DTOs.Role;

public class RoleGetDto
{
    public int Id { get; set; }
    public string RoleName { get; set; }
    public ICollection<UserRoleGetDto> UserRoles { get; set; }
}
