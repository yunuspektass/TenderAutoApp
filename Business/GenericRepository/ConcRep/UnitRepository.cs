using Business.GenericRepository.BaseRep;
using DataAccess;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.GenericRepository.ConcRep;

public class UnitRepository:BaseRepository<Unit>
{
    private TenderAutoAppContext _db;

    public UnitRepository(TenderAutoAppContext db) : base(db)
    {
        _db = db;
    }
    
    public async Task<IEnumerable<Unit>> GetItems()
    {
        return await _db.Units.Include(t => t.Tenders)
            .Include(u => u.Users)
            .ToListAsync();
    }

    public async Task<Unit?> GetItem(int id)
    {
        return await _db.Units.Include(t => t.Tenders)
            .Include(u => u.Users)
            .SingleOrDefaultAsync(p => p.Id == id);
    }
}