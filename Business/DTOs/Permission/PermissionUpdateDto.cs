namespace Business.DTOs.Permission;

public class PermissionUpdateDto
{
    public int Id { get; set; }
    public string PermissionName { get; set; }
    public ICollection<int> RoleIDs { get; set; }

}