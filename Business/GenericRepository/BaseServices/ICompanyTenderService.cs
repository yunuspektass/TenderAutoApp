using Business.DTOs.CompanyTender;

namespace Business.GenericRepository.BaseServices;

public interface ICompanyTenderService
{
    Task<IEnumerable<CompanyTenderGetDto>> GetList();
    Task<CompanyTenderGetDto> GetItem(int id);
    Task<CompanyTenderCreateDto> PostItem(CompanyTenderCreateDto companyTenderCreateDto);
    Task<bool> PutItem(int id, CompanyTenderUpdateDto companyTenderUpdateDto);
    Task<bool> DeleteItem(int id);
}