using Business.GenericRepository.BaseRep;
using DataAccess;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.GenericRepository.ConcRep;

public class TenderRepository:BaseRepository<Tender>
{
    private TenderAutoAppContext _db;

    public TenderRepository(TenderAutoAppContext db) : base(db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Tender>> GetItems()
    {
        return await _db.Tenders
            .Include(t => t.CompanyTenders)
            .Include(t => t.TenderProducts)
            .Include(t => t.TenderStatus)
            .Include(t => t.Unit)
            .Include(u => u.Users)
            .ToListAsync();

    }

    public async Task<Tender?> GetItem(int id)
    {
        return await _db.Tenders
            .Include(t => t.CompanyTenders)
            .Include(t => t.TenderProducts)
            .Include(t => t.TenderStatus)
            .Include(u => u.Users)
            .Include(t => t.Unit).SingleOrDefaultAsync(c => c.Id == id);
    }

   
    
    
}