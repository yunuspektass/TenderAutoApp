using Business.GenericRepository.BaseRep;
using DataAccess;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.GenericRepository.ConcRep;

public class UserCompanyRepository:BaseRepository<UserCompany>
{
    private TenderAutoAppContext _db;
    public UserCompanyRepository(TenderAutoAppContext db) : base(db)
    {
        _db = db;
    }


    public async Task<IEnumerable<UserCompany>> GetItems()
    {
        return await _db.UserCompanies
            .Include(u => u.Company)
            .Include(u => u.User)
            .ToListAsync();
    }

    public async Task<UserCompany?> GetItem(int id)
    {
        return await _db.UserCompanies
            .Include(u => u.Company)
            .Include(u => u.User)
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<User?> GetUser(int id)
    {
        return await _db.Users
            .Include(u => u.Roles)
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<bool> CheckCompanyExists(int companyId)
    {
        return await _db.Companies.AnyAsync(t => t.Id == companyId);
    }

    public async Task<UserCompany> FindUserCompany(int userId, int companyId)
    {
        return await _db.UserCompanies.FirstOrDefaultAsync(ut => ut.UserId == userId && ut.CompanyId == companyId);
    }

    public async Task AddUserCompany(UserCompany userCompany)
    {
        await _db.UserCompanies.AddAsync(userCompany);
        await _db.SaveChangesAsync();
    }


    public async Task<IEnumerable<UserCompany>> GetByUserId(int userId)
    {
        return await _db.UserCompanies.Where(uc => uc.UserId == userId).ToListAsync();
    }

    public async Task DeleteRange(IEnumerable<UserCompany> userCompanies)
    {
        _db.UserCompanies.RemoveRange(userCompanies);
        await Save();
    }

}
