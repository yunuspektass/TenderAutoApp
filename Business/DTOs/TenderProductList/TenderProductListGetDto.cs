using Business.DTOs.Category;
using Business.DTOs.TenderProduct;

namespace Business.DTOs.TenderProductListGetDto;

public class TenderProductListGetDto
{
    public int Id { get; set; }
    public int TenderId { get; set; }
    public CategoryGetDto Category { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime TenderDuration { get; set; }
    public DateTime TenderEntryDate { get; set; }
}