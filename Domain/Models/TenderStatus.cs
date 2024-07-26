using System.Collections;
using System.ComponentModel.DataAnnotations;
using Core.Domain;

namespace Domain.Models;

public class TenderStatus : BaseEntity
{
    [Required , MaxLength(50)]
    public string StatusName { get; set; }

    [MaxLength(200)]
    public string Description { get; set; }

    public virtual IEnumerable<Tender>? Tenders{ get; set; }
}