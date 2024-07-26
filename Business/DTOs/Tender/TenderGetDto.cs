using Business.DTOs.CompanyTender;
using Business.DTOs.TenderProduct;
using Business.DTOs.TenderStatus;
using Business.DTOs.Unit;
using Business.DTOs.User;

namespace Business.DTOs.Tender;

public class TenderGetDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string TenderType { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; }
    public UnitGetDto Unit { get; set; }
    public TenderStatusGetDto StatusInfo { get; set; }
    public ICollection<UserGetDto> Users { get; set; }
    public ICollection<TenderProductGetDto> TenderProducts { get; set; }
    public ICollection<CompanyTenderGetDto> CompanyTenders { get; set; }

    
}