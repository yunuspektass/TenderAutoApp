using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain;

namespace Domain.Models;

public class CompanyTender : BaseEntity
{
    [Required]
    [ForeignKey("Company")]
    public int CompanyId { get; set; }

    [Required]
    [ForeignKey("Tender")]
    public int TenderId { get; set; }

    [Required]
    public decimal AwardedAmount { get; set; }


    public virtual Company Company { get; set; }


    public virtual Tender Tender { get; set; }
}
