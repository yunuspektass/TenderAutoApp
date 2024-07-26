using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain;

namespace Domain.Models;

public class Notification : BaseEntity
{
    
    [Required , MaxLength(500)]
    public string Message { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }
    
    public virtual User User { get; set; }
    
}