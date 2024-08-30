using Business.GenericRepository.BaseRep;
using DataAccess;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.GenericRepository.ConcRep;

public class TenderProductRepository:BaseRepository<TenderProduct>
{
    private TenderAutoAppContext _db;

    public TenderProductRepository(TenderAutoAppContext db) : base(db)
    {
        _db = db;
    }

    public async Task<IEnumerable<TenderProduct>> GetItems()
    {
        return await _db.TenderProducts
            .Include(u => u.Product)
            .Include(u => u.Product)
            .ToListAsync();
    }

    public async Task<TenderProduct?> GetItem(int id)
    {
        return await _db.TenderProducts
            .Include(u => u.Product)
            .Include(u => u.Product)
            .SingleOrDefaultAsync();
    }

    public async Task RemoveProductsByTenderId(int tenderId)
    {
        var tenderProducts = _db.TenderProducts
            .Where(tp => tp.TenderId == tenderId);

        _db.TenderProducts.RemoveRange(tenderProducts);
        await _db.SaveChangesAsync();
    }

    public async Task<IEnumerable<TenderProduct>> GetTenderProducts(int tenderId)
    {
        return await _db.TenderProducts
            .Where(tp => tp.TenderId == tenderId && !tp.Deleted)
            .ToListAsync();
    }



}
