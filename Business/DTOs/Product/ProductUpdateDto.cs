namespace Business.DTOs.Urun;

public class ProductUpdateDto
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public int CategoryId { get; set; }
    public string Description { get; set; }
}
