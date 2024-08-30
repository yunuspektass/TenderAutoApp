using Business.DTOs.Role;
using Domain.Models;

namespace Business.GenericRepository.BaseServices;

public interface IRoleService
{
    Task<IEnumerable<RoleGetDto>> GetList();

    Task<RoleGetDto> GetItem(int id);

    Task<RoleCreateDto> PostItem(RoleCreateDto roleCreateDto);

    Task<bool> PutItem(int id, RoleUpdateDto roleUpdateDto);

    Task<bool> DeleteItem(int id);
}