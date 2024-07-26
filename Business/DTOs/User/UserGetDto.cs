using Business.DTOs.Company;
using Business.DTOs.Notification;
using Business.DTOs.Role;
using Business.DTOs.Tender;
using Business.DTOs.Unit;
using Core.Domain.Enums;

namespace Business.DTOs.User;

public class UserGetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    public string PhoneNumber { get; set; }
    public string Address { get; set; }

    public UnitGetDto Unit { get; set; }
    public CompanyGetDto Company { get; set; }
    public ICollection<NotificationGetDto> Notifications { get; set; }
    public ICollection<TenderGetDto> Tenders { get; set; }
    public ICollection<RoleGetDto> Roles { get; set; }

}