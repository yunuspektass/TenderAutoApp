using Business.GenericRepository.BaseRep;
using DataAccess;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.GenericRepository.ConcRep;

public class RolePermissionRepository:BaseRepository<RolePermission>
{
    private  TenderAutoAppContext _db;
    
    public RolePermissionRepository(TenderAutoAppContext db) : base(db)
    {
        _db = db;
    }
    
    public async Task<IEnumerable<RolePermission>> GetItems()
    {
        return await _db.RolePermissions.Include(u => u.Permission)
            .Include(u => u.Role)
            .ToListAsync();
    }

    public async Task<RolePermission?> GetItem(int id)
    {
        return await _db.RolePermissions.Include(u => u.Permission)
            .Include(u => u.Role).FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task UpdateRolePermission(RolePermission rolePermission)
    {
        var existingRolePermission = await _db.RolePermissions.FirstOrDefaultAsync(rp => rp.Id == rolePermission.Id);

        if (existingRolePermission != null)
        {
            existingRolePermission.Deleted = rolePermission.Deleted;

            _db.RolePermissions.Update(existingRolePermission);
            await _db.SaveChangesAsync();
        }
    }
}