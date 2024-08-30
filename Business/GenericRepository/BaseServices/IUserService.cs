using Business.DTOs.User;
using Domain.Models;

namespace Business.GenericRepository.BaseServices;

public interface IUserService
{
    Task<IEnumerable<UserGetDto>> GetList();

    Task<UserGetDto> GetItem(int id);

    Task<User> PostItem(UserCreateDto userCreateDto);

    Task<bool> PutItem(int id, UserUpdateDto userUpdateDto);

    Task<bool> DeleteItem(int id);

    Task<UserGetDto> GetByEmail(string email);

    Task AddTendersToUser(int userId, List<int> tenderIds);

    Task AddCompaniesToUser(int userId, List<int> companyIds);




}
