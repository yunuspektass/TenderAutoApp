using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain;

namespace Domain.Models;

public class UserCompany:BaseEntity
{
    [Required]
    [ForeignKey("User")]
    public int UserId { get; set; }
    public virtual User User { get; set; }

    [Required]
    [ForeignKey("Company")]
    public int? CompanyId { get; set; }
    public virtual Company Company { get; set; }
}
