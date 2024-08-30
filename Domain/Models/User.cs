using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain;
using Core.Domain.Enums;

namespace Domain.Models;

public class User : BaseEntity
{
    [Required , MaxLength(100)]
    public string Name { get; set; }

    [Required , MaxLength(100)]
    public string LastName { get; set; }

    [Required , MaxLength(256)]
    public string Password { get; set; }

    [Required , MaxLength(100)]
    public string Email { get; set; }

    [MaxLength(15)]
    public string PhoneNumber { get; set; }

    [MaxLength(200)]
    public string Address { get; set; }



    [ForeignKey("Unit")]
    public int? UnitId { get; set; }
    public virtual Unit  Unit { get; set; }


    public ICollection<UserRole> Roles { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; }
    public virtual ICollection<UserTender> UserTenders { get; set; }

    public virtual ICollection<UserCompany> UserCompanies { get; set; }



}
