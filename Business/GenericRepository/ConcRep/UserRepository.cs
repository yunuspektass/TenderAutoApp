using Business.GenericRepository.BaseRep;
using DataAccess;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.GenericRepository.ConcRep;

public class UserRepository:BaseRepository<User>
{
    private TenderAutoAppContext _db;
    public UserRepository(TenderAutoAppContext db) : base(db)
    {
        _db = db;
    }
    
    public async Task<IEnumerable<User>> GetItems()
    {
        return await _db.Users.Include(u => u.Unit)
            .Include(u => u.Tenders)
            .Include(u => u.Company)
            .Include(u => u.Notifications)
            .ToListAsync();
    }

    public async Task<User?> GetItem(int id)
    {
        return await _db.Users.Include(t => t.Tenders)
            .Include(t => t.Unit)
            .Include(t => t.Company)
            .Include(t => t.Notifications)
            .SingleOrDefaultAsync(p => p.Id == id);
    }
    
    public IQueryable<User> GetItemsAsQueryable()
    {
        return _db.Users.AsQueryable();
    }
    
    public async Task AddUserRole(UserRole userRole)
    {
        await _db.UserRoles.AddAsync(userRole);
        await _db.SaveChangesAsync();
    }
    
    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _db.Users
            .Include(u => u.Roles)
            .ThenInclude(ur => ur.Role)
            .FirstOrDefaultAsync(u => u.Email == email);
        
    }
    
    
    
}