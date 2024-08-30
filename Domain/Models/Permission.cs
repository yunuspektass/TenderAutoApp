using System.ComponentModel.DataAnnotations;
using Core.Domain;

namespace Domain.Models;

public class Permission:BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string PermissionName { get; set; }

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}