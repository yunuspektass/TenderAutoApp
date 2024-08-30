using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Core.Domain;

public abstract class BaseEntity : ISoftDeletable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    
    public string? CreatedBy { get; set; }
    
    public string? UpdatedBy { get; set; }
    
    public string? DeletedBy { get; set; }
    
    
    
    [Required]
    public bool Deleted { get; set; }
    
 
    
}