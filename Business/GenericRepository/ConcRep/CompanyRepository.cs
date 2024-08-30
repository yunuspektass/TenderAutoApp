using Business.GenericRepository.BaseRep;
using DataAccess;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.GenericRepository.ConcRep;

public class CompanyRepository:BaseRepository<Company>
{
    private TenderAutoAppContext _db;

    public CompanyRepository(TenderAutoAppContext db) : base(db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Company>> GetItems()
    {
        return await _db.Companies
            .Include(c => c.CompanyTenders)
            .ToListAsync();
    }

    public async Task<Company?> GetItem(int id)
    {
        return await _db.Companies
            .Include(c => c.CompanyTenders)
            .SingleOrDefaultAsync(c => c.Id == id);
    }


    public async Task<UserCompany> FindUserCompany(int userId, int companyId)
    {
        return await _db.UserCompanies.FirstOrDefaultAsync(ut => ut.UserId == userId && ut.CompanyId == companyId);
    }


    public async Task RemoveUsersByCompanyId(int companyId)
    {
        var companies = _db.UserCompanies
            .Where(tp => tp.CompanyId == companyId);

        _db.UserCompanies.RemoveRange(companies);
        await _db.SaveChangesAsync();
    }




}
