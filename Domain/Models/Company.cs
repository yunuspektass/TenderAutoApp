using System.Collections;
using System.ComponentModel.DataAnnotations;
using Core.Domain;

namespace Domain.Models;

public class Company : BaseEntity
{
    [Required , MaxLength(100)]
    public string CompanyName { get; set; }

    [MaxLength(200)]
    public string Address { get; set; }

    [MaxLength(200)]
    public string ContactInformation { get; set; }

    [MaxLength(50)]
    public string TaxNumber { get; set; }

    public string Sector { get; set; }

    public virtual ICollection<Offer> Offers { get; set; }
    public virtual ICollection<CompanyTender> CompanyTenders { get; set; }

    public virtual ICollection<UserCompany> UserCompanies { get; set; }

}
