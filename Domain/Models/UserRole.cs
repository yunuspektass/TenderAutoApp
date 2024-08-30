using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain;

namespace Domain.Models;

public class UserRole:BaseEntity
{

  [Required]
  [ForeignKey("User")]
    public int UserId { get; set; }
    public User User { get; set; }

    [Required]
    [ForeignKey("Role")]
    public int RoleId { get; set; }
    public Role Role { get; set; }
}
