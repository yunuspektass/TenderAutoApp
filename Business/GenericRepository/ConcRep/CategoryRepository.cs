using Business.GenericRepository.BaseRep;
using DataAccess;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.GenericRepository.ConcRep;

public class CategoryRepository:BaseRepository<Category>
{
    private TenderAutoAppContext _db;
    public CategoryRepository(TenderAutoAppContext db) : base(db)
    {
        _db = db;
    }
    
    
    public async Task<IEnumerable<Category>> GetItems()
    {
        return await _db.Categories.Include(p => p.Products)
            .Include(t => t.TenderProductLists)
            .ToListAsync();
    }

    public async Task<Category?> GetItem(int id)
    {
        return await _db.Categories.Include(p => p.Products)
            .Include(t => t.TenderProductLists)

            .SingleOrDefaultAsync(p => p.Id == id);
    }
}