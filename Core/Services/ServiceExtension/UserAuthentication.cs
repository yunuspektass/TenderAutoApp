using System.ComponentModel.DataAnnotations;
using Core.Domain.Enums;

namespace Core.Services.ServiceExtension;

public class UserAuthentication
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }


    [Required]
    public string Password { get; set; }
}
    
