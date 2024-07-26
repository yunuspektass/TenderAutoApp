using Business.GenericRepository.BaseRep;
using DataAccess;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.GenericRepository.ConcRep;

public class TenderProductListRepository:BaseRepository<TenderProductList>
{
    private TenderAutoAppContext _db;
    public TenderProductListRepository(TenderAutoAppContext db) :base(db)
    {
        _db = db;
    }
    
    public async Task<IEnumerable<TenderProductList>> GetItems()
    {
        return await _db.TenderProductLists.Include(u => u.Tender)
            .Include(u => u.Category)
            .ToListAsync();
    }

    public async Task<TenderProductList?> GetItem(int id)
    {
        return await _db.TenderProductLists.Include(c => c.Tender)
            .Include(u => u.Category)
            .SingleOrDefaultAsync();
    }
}