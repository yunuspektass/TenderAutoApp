using Business.GenericRepository.BaseRep;
using DataAccess;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.GenericRepository.ConcRep;

public class PermissionRepository:BaseRepository<Permission>
{
    private TenderAutoAppContext _db;

    public PermissionRepository(TenderAutoAppContext db) : base(db)
    {
        _db = db;
    }
    
    
    public async Task<IEnumerable<Permission>> GetItems()
    {
        return await _db.Permissions.Include(u => u.RolePermissions)
            .ToListAsync();
    }

    public async Task<Permission?> GetItem(int id)
    {
        return await _db.Permissions.Include(c => c.RolePermissions)
            .FirstOrDefaultAsync();
    }
}