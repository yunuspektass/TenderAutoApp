using Business.DTOs.Company;

namespace Business.GenericRepository.BaseServices;

public interface ICompanyService
{
    Task<IEnumerable<CompanyGetDto>> GetList();

    Task<CompanyGetDto> GetItem(int id);

    Task<CompanyCreateDto> PostItem(CompanyCreateDto companyCreateDto);

    Task<bool> PutItem(int id, CompanyUpdateDto companyUpdateDto);

    Task<bool> DeleteItem(int id);

    public Task AddUsersToCompany(int companyId, List<int> userIds);

}
