using System.Collections;
using System.ComponentModel.DataAnnotations;
using Core.Domain;

namespace Domain.Models;

public class Category : BaseEntity
{
    [Required , MaxLength(100)]
    public string CategoryName { get; set; }
    
    
    public virtual ICollection<Product> Products { get; set; }
    public virtual ICollection<TenderProductList> TenderProductLists { get; set; }
    
}