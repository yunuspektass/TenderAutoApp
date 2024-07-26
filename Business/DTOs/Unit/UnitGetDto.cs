using Business.DTOs.Tender;
using Business.DTOs.User;

namespace Business.DTOs.Unit;

public class UnitGetDto
{
    public int Id { get; set; }
    public string UnitName { get; set; }

    public ICollection<TenderGetDto> Tenders { get; set; }
    public ICollection<UserGetDto> Users { get; set; }

}