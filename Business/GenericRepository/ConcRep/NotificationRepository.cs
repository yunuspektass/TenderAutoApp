using Business.GenericRepository.BaseRep;
using DataAccess;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.GenericRepository.ConcRep;

public class NotificationRepository:BaseRepository<Notification>
{
    private TenderAutoAppContext _db;

    public NotificationRepository(TenderAutoAppContext db) : base(db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Notification>> GetItems()
    {
        return await _db.Notifications.Include(u => u.User)
            .ToListAsync();
    }

    public async Task<Notification?> GetItem(int id)
    {
        return await _db.Notifications.Include(u => u.User)
            .SingleOrDefaultAsync(c => c.Id == id);
    }
    
     
}