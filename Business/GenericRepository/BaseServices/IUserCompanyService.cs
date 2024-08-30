using Business.DTOs.UserCompany;
using Domain.Models;

namespace Business.GenericRepository.BaseServices;

public interface IUserCompanyService
{
    Task<IEnumerable<UserCompanyGetDto>> GetList();

    Task<UserCompanyGetDto> GetItem(int id);

    Task<UserCompany> PostItem(UserCompanyCreateDto userCompanyCreateDto);

    Task<bool> PutItem(int id, UserCompanyUpdateDto userCompanyUpdateDto);

    Task<bool> DeleteItem(int id);

    Task<bool> DeleteUserCompaniesByUserId(int userId);

}
