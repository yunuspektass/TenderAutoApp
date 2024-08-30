using Business.DTOs.Unit;

namespace Business.GenericRepository.BaseServices;

public interface IUnitService
{
    Task<IEnumerable<UnitGetDto>> GetList();

    Task<UnitGetDto> GetItem(int id);

    Task<UnitCreateDto> PostItem(UnitCreateDto unitCreateDto);

    Task<bool> PutItem(int id, UnitUpdateDto unitUpdateDto);

    Task<bool> DeleteItem(int id);
}