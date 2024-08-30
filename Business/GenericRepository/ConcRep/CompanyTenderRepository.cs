using System.Collections;
using Business.GenericRepository.BaseRep;
using DataAccess;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.GenericRepository.ConcRep;

public class CompanyTenderRepository:BaseRepository<CompanyTender>
{
    private TenderAutoAppContext _db;

    public CompanyTenderRepository(TenderAutoAppContext db) : base(db)
    {
        _db = db;
    }
    
    public async Task<IEnumerable<CompanyTender>> GetItems()
    {
        return await _db.CompanyTenders
            .Include(c => c.Company)
            .Include(c => c.Tender)
            .ToListAsync();
    }

    public async Task<CompanyTender?> GetItem(int id)
    {
        return await _db.CompanyTenders
            .Include(c => c.Company)
            .Include(c => c.Tender)
            .SingleOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<CompanyTender>> GetCompanyTendersByCompanyId(int companyId)
    {
        return await _db.CompanyTenders.Where(ct => ct.CompanyId == companyId && !ct.Deleted).ToListAsync();
    }
    
}