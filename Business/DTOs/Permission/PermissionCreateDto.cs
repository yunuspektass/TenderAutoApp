namespace Business.DTOs.Permission;

public class PermissionCreateDto
{
    public string PermissionName { get; set; }
    
    public ICollection<int> RoleIDs { get; set; }

}