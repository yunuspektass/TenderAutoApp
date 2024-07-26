namespace Business.DTOs.CompanyTender;

public class CompanyTenderCreateDto
{
    public int CompanyId { get; set; }
    public int TenderId { get; set; }
    public decimal AwardedAmount { get; set; }
}