using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain;

namespace Domain.Models;

public class TenderProduct: BaseEntity
{
    [Required]  
    [ForeignKey("Tender")]
    public int TenderId { get; set; }

    [Required] 
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    
    [Required]
    public int Quantity { get; set; }

    [Required]
    public decimal UnitPrice { get; set; }

    public decimal TotalPrice { get; set; }
    public DateTime TenderDuration { get; set; }
    public DateTime TenderEntryDate { get; set; }
    
    public virtual Tender Tender { get; set; }
    
    public virtual Product Product { get; set; }
}