

using Business.DTOs.Product;

namespace Business.DTOs.Category;

public class CategoryGetDto
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public ICollection<TenderProductListGetDto.TenderProductListGetDto> TenderProductLists { get; set; }
}
