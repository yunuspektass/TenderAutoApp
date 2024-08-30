using Business.DTOs.Category;
using Business.DTOs.TenderProduct;
using Domain.Models;

namespace Business.DTOs.Product;

public class ProductGetDto
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }

    public CategoryGetDto Category { get; set; }
}
