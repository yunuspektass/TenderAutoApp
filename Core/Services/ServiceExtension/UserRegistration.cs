using System.ComponentModel.DataAnnotations;

namespace Core.Services.ServiceExtension;

public class UserRegistration
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }



    public string PhoneNumber { get; set; }

    public string Address { get; set; }
}
