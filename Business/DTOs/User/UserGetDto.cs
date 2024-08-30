using Business.DTOs.Company;
using Business.DTOs.Notification;
using Business.DTOs.Role;
using Business.DTOs.Tender;
using Business.DTOs.Unit;
using Core.Domain.Enums;
using Domain.Models;

namespace Business.DTOs.User;

public class UserGetDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public string PhoneNumber { get; set; }
    public string Address { get; set; }


    public ICollection<RoleGetDto> Roles { get; set; }

   public List<int> TenderIds { get; set; } = new List<int>();

   public List<int> CompanyIds { get; set; } = new List<int>();






}
