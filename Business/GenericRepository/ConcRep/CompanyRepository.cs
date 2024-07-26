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
            .Include(u => u.Users)
            .ToListAsync();
    }

    public async Task<Company?> GetItem(int id)
    {
        return await _db.Companies
            .Include(c => c.CompanyTenders)
            .Include(u => u.Users)
            .SingleOrDefaultAsync(c => c.Id == id);
    }


    
    
}