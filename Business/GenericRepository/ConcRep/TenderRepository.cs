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
            .Include(t => t.Unit)
            .ToListAsync();

    }

    public async Task<Tender?> GetItem(int id)
    {
        return await _db.Tenders
            .Include(t => t.CompanyTenders)
            .Include(t => t.TenderProducts)
            .Include(t => t.Unit).SingleOrDefaultAsync(c => c.Id == id);
    }


    public async Task<UserTender> FindUserTender(int userId, int tenderId)
    {
        return await _db.UserTenders.FirstOrDefaultAsync(ut => ut.UserId == userId && ut.TenderId == tenderId);
    }


    public async Task RemoveUsersByTenderId(int tenderId)
    {
        var tenderProducts = _db.UserTenders
            .Where(tp => tp.TenderId == tenderId);

        _db.UserTenders.RemoveRange(tenderProducts);
        await _db.SaveChangesAsync();
    }


}
