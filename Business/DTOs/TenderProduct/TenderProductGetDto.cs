using Business.DTOs.Product;
using Business.DTOs.Tender;

namespace Business.DTOs.TenderProduct;

public class TenderProductGetDto
{
    public int TenderId { get; set; }
    public TenderGetDto Tender { get; set; }
    public int ProductId { get; set; }
    public ProductGetDto Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}