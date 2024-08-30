using Business.DTOs.Product;
using Business.DTOs.Urun;

namespace Business.GenericRepository.BaseRep;

public interface IProductService
{
    Task<IEnumerable<ProductGetDto>>  GetList();
    Task<ProductGetDto> GetItem(int id);

    Task<ProductCreateDto> PostItem(ProductCreateDto productCreateDto);

    Task<bool> PutItem(int id, ProductUpdateDto productUpdateDto);

    Task<bool> DeleteItem(int id);


}
