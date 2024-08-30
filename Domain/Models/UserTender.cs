using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain;
using Newtonsoft.Json;

namespace Domain.Models;

public class UserTender:BaseEntity
{

  [Required]
  [ForeignKey("User")]
  public int UserId { get; set; }
  public virtual User User { get; set; }

  [Required]
  [ForeignKey("Tender")]
  public int? TenderId { get; set; }
  public virtual Tender Tender { get; set; }
}
