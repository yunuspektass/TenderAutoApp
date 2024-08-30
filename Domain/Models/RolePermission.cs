using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain;

namespace Domain.Models;

public class RolePermission : BaseEntity
{
    
    [Required]
    [ForeignKey("Role")]
    public int RoleId { get; set; }
    public Role Role { get; set; }

    [Required]
    [ForeignKey("Permission")]
    public int PermissionId { get; set; }
    public Permission Permission { get; set; }
}