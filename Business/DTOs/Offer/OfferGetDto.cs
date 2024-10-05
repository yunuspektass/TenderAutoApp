using Business.DTOs.Company;
using Business.DTOs.Tender;

namespace Business.DTOs.Offer;

public class OfferGetDto
{
    public int Id { get; set; }
    public int TenderId { get; set; }
    public int CompanyId { get; set; }
    public decimal Amount { get; set; }
    public DateTime OfferDate { get; set; }
    public decimal AverageOffer { get; set; }
    public decimal LowestOffer1 { get; set; }
    public decimal LowestOffer2 { get; set; }
    public decimal LowestOffer3 { get; set; }
}
