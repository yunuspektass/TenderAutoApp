using Core.Domain.Enums;

namespace Business.DTOs.User;

public class UserCreateDto
{
    public string Name { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string Address { get; set; }
    
    public List<int> RoleIds { get; set; }
    
}