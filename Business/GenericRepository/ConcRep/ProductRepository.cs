using Business.GenericRepository.BaseRep;
using DataAccess;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.GenericRepository.ConcRep;

public class ProductRepository:BaseRepository<Product>
{
    private TenderAutoAppContext _db;

    public ProductRepository(TenderAutoAppContext db) : base(db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Product>> GetItems()
    {
        return await _db.Products
            .Include(u => u.Category)
            .ToListAsync();
    }

    public async Task<Product?> GetItem(int id)
    {
        return await _db.Products
            .Include(u => u.Category)
            .SingleOrDefaultAsync(p => p.Id == id);
    }
}
