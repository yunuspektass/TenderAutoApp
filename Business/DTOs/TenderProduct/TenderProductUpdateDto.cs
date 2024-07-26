namespace Business.DTOs.TenderProduct;

public class TenderProductUpdateDto
{
    public int TenderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}