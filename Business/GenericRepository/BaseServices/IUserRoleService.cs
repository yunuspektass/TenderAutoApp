using Business.DTOs.UserRole;

namespace Business.GenericRepository.BaseServices;

public interface IUserRoleService
{
    Task<IEnumerable<UserRoleGetDto>> GetList();

    Task<UserRoleGetDto> GetItem(int id);

    Task<UserRoleCreateDto> PostItem(UserRoleCreateDto userRoleCreateDto);

    Task<bool> PutItem(int id, UserRoleUpdateDto userRoleUpdateDto);

    Task<bool> DeleteItem(int id);
}