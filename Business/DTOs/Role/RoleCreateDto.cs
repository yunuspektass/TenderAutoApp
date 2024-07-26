using System.ComponentModel.DataAnnotations;
using Core.Domain.Enums;

namespace Business.DTOs.Role;

public class RoleCreateDto
{
    public string RoleName { get; set; }

}