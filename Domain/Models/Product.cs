using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain;

namespace Domain.Models;

public class Product: BaseEntity
{
    [Required , MaxLength(100)]
    public string ProductName { get; set; }
    
    [MaxLength(500)]
    public string Description { get; set; }
    
    [Required]
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    

    public virtual Category Category { get; set; }
    
    public virtual ICollection<TenderProduct> TenderProducts { get; set; }
    
    
}