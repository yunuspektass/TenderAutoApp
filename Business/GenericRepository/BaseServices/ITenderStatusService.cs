using Business.DTOs.TenderStatus;

namespace Business.GenericRepository.BaseServices;

public interface ITenderStatusService
{
    Task<IEnumerable<TenderStatusGetDto>> GetList();

    Task<TenderStatusGetDto> GetItem(int id);

    Task<TenderStatusCreateDto> PostItem(TenderStatusCreateDto tenderStatusCreate);

    Task<bool> PutItem(int id, TenderStatusUpdateDto tenderStatusUpdateDto);

    Task<bool> DeleteItem(int id);
}