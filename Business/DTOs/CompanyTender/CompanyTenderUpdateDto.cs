namespace Business.DTOs.CompanyTender;

public class CompanyTenderUpdateDto
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public int TenderId { get; set; }
    public decimal AwardedAmount { get; set; }
}