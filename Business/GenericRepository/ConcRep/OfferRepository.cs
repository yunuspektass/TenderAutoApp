using Business.GenericRepository.BaseRep;
using DataAccess;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.GenericRepository.ConcRep;

public class OfferRepository:BaseRepository<Offer>
{
    private TenderAutoAppContext _db;

    public OfferRepository(TenderAutoAppContext db) : base(db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Offer>> GetItems()
    {
        return await _db.Offers
            .Include(o => o.Tender)
            .Include(o => o.Company)
            .ToListAsync();
    }

    public async Task<Offer?> GetItem(int id)
    {
        return await _db.Offers
            .Include(o => o.Tender)
            .Include(o => o.Company)
            .SingleOrDefaultAsync(c => c.Id == id);
    }
}