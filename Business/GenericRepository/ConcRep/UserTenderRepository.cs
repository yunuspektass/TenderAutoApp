using Business.GenericRepository.BaseRep;
using DataAccess;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.GenericRepository.ConcRep;

public class UserTenderRepository:BaseRepository<UserTender>
{
  private TenderAutoAppContext _db;
  public UserTenderRepository(TenderAutoAppContext db) : base(db)
  {
    _db = db;
  }


  public async Task<IEnumerable<UserTender>> GetItems()
  {
      return await _db.UserTenders
          .Include(u => u.Tender)
          .Include(u => u.User)
          .ToListAsync();
  }

  public async Task<UserTender?> GetItem(int id)
  {
      return await _db.UserTenders
          .Include(u => u.Tender)
          .Include(u => u.User)
          .SingleOrDefaultAsync(p => p.Id == id);
  }

  public async Task<User?> GetUser(int id)
  {
      return await _db.Users
          .Include(u => u.Roles)
          .SingleOrDefaultAsync(p => p.Id == id);
  }

  public async Task<bool> CheckTenderExists(int tenderId)
  {
      return await _db.Tenders.AnyAsync(t => t.Id == tenderId);
  }

  public async Task<UserTender> FindUserTender(int userId, int tenderId)
  {
      return await _db.UserTenders.FirstOrDefaultAsync(ut => ut.UserId == userId && ut.TenderId == tenderId);
  }

  public async Task AddUserTender(UserTender userTender)
  {
      await _db.UserTenders.AddAsync(userTender);
      await _db.SaveChangesAsync();
  }

  public async Task<IEnumerable<UserTender>> GetByUserId(int userId)
  {
      return await _db.UserTenders.Where(uc => uc.UserId == userId).ToListAsync();
  }

  public async Task DeleteRange(IEnumerable<UserTender> userTenders)
  {
      _db.UserTenders.RemoveRange(userTenders);
      await Save();
  }

}
