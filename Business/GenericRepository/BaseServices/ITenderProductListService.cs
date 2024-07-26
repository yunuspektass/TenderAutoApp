using Business.DTOs.TenderProductListGetDto;

namespace Business.GenericRepository.BaseServices;

public interface ITenderProductListService
{
    Task<IEnumerable<TenderProductListGetDto>> GetList();

    Task<TenderProductListGetDto> GetItem(int id);

    Task<TenderProductListCreateDto> PostItem(TenderProductListCreateDto tenderProductListCreateDto);

    Task<bool> PutItem(int id, TenderProductListUpdateDto tenderProductListUpdateDto);

    Task<bool> DeleteItem(int id);
}