using Business.DTOs.CompanyTender;
using Business.DTOs.TenderProduct;
using Business.DTOs.Unit;
using Business.DTOs.User;
using Business.DTOs.UserTender;

namespace Business.DTOs.Tender;

public class TenderGetDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string TenderType { get; set; }
    public string Description { get; set; }
    public decimal Budget { get; set; }
    public bool IsFinished { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; }
    public UnitGetDto Unit { get; set; }
    public int? WinnerCompanyId { get; set; }



}
