using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain;
using Core.Domain.Enums;

namespace Domain.Models;

public class Tender  : BaseEntity
{
    [Required,MaxLength(200)]
    public string Title { get; set; }

    [MaxLength(1000)]
    public string Description { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    public bool IsFinished { get; set; } = false;

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    [ForeignKey("Unit")]
    public int UnitId { get; set; }



    [MaxLength(50)]
    public TenderTypes TenderType { get; set; }

    [Required]
    public decimal Budget { get; set; }

    [ForeignKey("WinnerCompany")]
    public int? WinnerCompanyId { get; set; }


    public virtual Unit Unit { get; set; }

    public virtual Company WinnerCompany { get; set; }


    public virtual ICollection<UserTender> UserTenders { get; set; }


    public virtual ICollection<Offer> Offers { get; set; }

    public virtual ICollection<TenderProduct> TenderProducts { get; set; }

    public virtual ICollection<TenderProductList> TenderProductLists { get; set; }

    public virtual ICollection<CompanyTender> CompanyTenders { get; set; }

}
