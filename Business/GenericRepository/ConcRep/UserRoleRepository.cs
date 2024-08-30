using Business.GenericRepository.BaseRep;
using DataAccess;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.GenericRepository.ConcRep;

public class UserRoleRepository:BaseRepository<UserRole>
{

    private TenderAutoAppContext _db;
    
    public UserRoleRepository(TenderAutoAppContext db) : base(db)
    {
        _db = db;
    }
    
    public async Task<IEnumerable<UserRole>> GetItems()
    {
        return await _db.UserRoles.Include(t => t.User)
            .Include(u => u.Role)
            .ToListAsync();
    }

    public async Task<UserRole?> GetItem(int id)
    {
        return await _db.UserRoles.Include(t => t.User)
            .Include(u => u.Role)
            .SingleOrDefaultAsync(p => p.Id == id);
    }

}