using Core.Domain.Enums;

namespace Business.DTOs.User;

public class UserUpdateDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string LastName { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Address { get; set; }
    public List<int> RoleIds { get; set; }


    public List<int?> TenderIds { get; set; } = new List<int?>();

    public List<int?> CompanyIds { get; set; } = new List<int?>();




}
