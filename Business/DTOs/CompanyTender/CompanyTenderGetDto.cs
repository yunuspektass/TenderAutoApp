using Business.DTOs.Company;
using Business.DTOs.Tender;

namespace Business.DTOs.CompanyTender;

public class CompanyTenderGetDto
{
    public int Id { get; set; }
    public CompanyGetDto Company { get; set; }
    public TenderGetDto Tender { get; set; }
    public decimal AwardedAmount { get; set; }
}