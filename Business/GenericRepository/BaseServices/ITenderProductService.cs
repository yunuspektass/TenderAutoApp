using Business.DTOs.TenderProduct;

namespace Business.GenericRepository.BaseServices;

public interface ITenderProductService
{
    Task<IEnumerable<TenderProductGetDto>> GetList();
    Task<TenderProductGetDto> GetItem(int id);
    Task<TenderProductCreateDto> PostItem(TenderProductCreateDto tenderProductCreate);
    Task<bool> PutItem(int id, TenderProductUpdateDto tenderProductUpdateDto);
    Task<bool> DeleteItem(int id);
}