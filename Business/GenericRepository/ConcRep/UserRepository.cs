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
        return await _db.Users
            .Include(u => u.Roles)
            .ToListAsync();
    }

    public async Task<User?> GetItem(int id)
    {
        return await _db.Users
            .Include(u => u.Roles)
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

    public async Task<bool> CheckTenderExists(int tenderId)
    {
        return await _db.Tenders.AnyAsync(t => t.Id == tenderId);
    }

    public async Task<UserTender> FindUserTender(int userId, int tenderId)
    {
        return await _db.UserTenders.FirstOrDefaultAsync(ut => ut.UserId == userId && ut.TenderId == tenderId);
    }

    public async Task<UserCompany> FindUserCompany(int userId, int companyId)
    {
        return await _db.UserCompanies.FirstOrDefaultAsync(ut => ut.UserId == userId && ut.CompanyId == companyId);
    }

    public async Task AddUserTender(UserTender userTender)
    {
        await _db.UserTenders.AddAsync(userTender);
        await _db.SaveChangesAsync();
    }

    public async Task RemoveRolesByUserId(int userId)
    {
        var userRole = _db.UserRoles
            .Where(tp => tp.UserId == userId);

        _db.UserRoles.RemoveRange(userRole);
        await _db.SaveChangesAsync();
    }


    public async Task<IEnumerable<UserRole>> GetUserRoles(int userId)
    {
        return await _db.UserRoles
            .Where(ur => ur.UserId == userId)
            .ToListAsync();
    }



}
