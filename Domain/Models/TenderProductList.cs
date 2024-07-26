using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain;

namespace Domain.Models;

public class TenderProductList : BaseEntity
{
    [Required]
    [ForeignKey("Tender")]
    public int TenderId { get; set; }

    [Required]
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    
    public string ProductName { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    
    public DateTime TenderDuration { get; set; }
    public DateTime TenderEntryDate { get; set; }
    
    public Tender Tender { get; set; }
    public Category Category { get; set; }
    
    
}