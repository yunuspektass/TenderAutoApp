using Core.Domain;

namespace Domain.Models;

public class Role:BaseEntity
{
    public string RoleName { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
    
    public virtual ICollection<RolePermission> RolePermissions { get; set; }
}