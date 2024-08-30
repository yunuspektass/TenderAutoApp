using System.Collections;
using System.ComponentModel.DataAnnotations;
using Core.Domain;

namespace Domain.Models;

public class Unit : BaseEntity
{
    [Required , MaxLength(100)]
    public string UnitName { get; set; }

    public virtual ICollection<Tender> Tenders { get; set; }
    
    public virtual ICollection<User> Users { get; set; }
    
}