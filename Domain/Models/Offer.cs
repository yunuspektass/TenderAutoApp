using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain;

namespace Domain.Models;

public class Offer: BaseEntity
{
    [Required]
    [ForeignKey("Tender")]
    public int TenderId { get; set; }
    
    [Required]
    [ForeignKey("Company")]
    public int CompanyId { get; set; }
    
    [Required]
    public decimal Amount { get; set; }
    
    [Required]
    public DateTime OfferDate { get; set; }
    
    public decimal AverageOffer { get; set; }
    public decimal LowestOffer1 { get; set; }
    public decimal LowestOffer2 { get; set; }
    public decimal LowestOffer3 { get; set; }

    
    public virtual Tender Tender { get; set; }


    public virtual Company Company { get; set; }
}
