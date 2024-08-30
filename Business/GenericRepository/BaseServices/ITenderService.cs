using Business.DTOs.Tender;

namespace Business.GenericRepository.BaseServices;

public interface ITenderService
{
    Task<IEnumerable<TenderGetDto>> GetList();
    Task<TenderGetDto> GetItem(int id);
    Task<TenderCreateDto> PostItem(TenderCreateDto tenderCreateDto);
    Task<bool> PutItem(int id, TenderUpdateDto tenderUpdateDto);
    Task<bool> DeleteItem(int id);

     Task AddUsersToTender(int tenderId, List<int> userIds);

}
