using Business.GenericRepository.BaseRep;
using DataAccess;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.GenericRepository.ConcRep;

public class RoleRepository: BaseRepository<Role>
{
    private readonly TenderAutoAppContext _db;

    public RoleRepository(TenderAutoAppContext db) : base(db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Role>> GetItems()
    {
        return await _db.Roles.Include(u => u.RolePermissions)
            .Include(u => u.UserRoles)
            .ToListAsync();
    }

    public async Task<Role?> GetItem(int id)
    {
        return await _db.Roles.Include(u => u.RolePermissions)
            .Include(u => u.UserRoles).SingleOrDefaultAsync(r => r.Id == id);
    }

    public async Task<Role?> GetByIdAsync(int roleId)
    {
        return await _db.Set<Role>().FindAsync(roleId);
    }

}
