using Business.GenericRepository.BaseRep;
using DataAccess;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.GenericRepository.ConcRep;

public class TenderStatusRepository:BaseRepository<TenderStatus>
{
    private TenderAutoAppContext _db;

    public TenderStatusRepository(TenderAutoAppContext db) : base(db)
    {
        _db = db;
    }
    
    public async Task<IEnumerable<TenderStatus>> GetItems()
    {
        return await _db.TenderStatuses
            .Include(t => t.Tenders)
            .ToListAsync();
        
    }

    public async Task<TenderStatus?> GetItem(int id)
    {
        return await _db.TenderStatuses
            .Include(t => t.Tenders)
            .SingleOrDefaultAsync();
    }
}