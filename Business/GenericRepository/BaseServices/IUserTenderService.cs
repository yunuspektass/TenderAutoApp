using Business.DTOs.UserTender;
using Domain.Models;

namespace Business.GenericRepository.BaseServices;

public interface IUserTenderService
{
    Task<IEnumerable<UserTenderGetDto>> GetList();

    Task<UserTenderGetDto> GetItem(int id);

    Task<UserTender> PostItem(UserTenderCreateDto userTenderCreateDto);

    Task<bool> PutItem(int id, UserTenderUpdateDto userTenderUpdateDto);

    Task<bool> DeleteItem(int id);

    Task<bool> DeleteUserTendersByUserId(int userId);

}
