using System.Linq.Expressions;
using Business.GenericRepository.IntRep;
using Core.Domain;
using DataAccess;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.GenericRepository.BaseRep;

public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly TenderAutoAppContext _db;

    protected BaseRepository(TenderAutoAppContext db)
    {
        _db = db;
    }

   public async Task Save()
    {
        
        await _db.SaveChangesAsync();
    }

    public async Task<List<T>> GetAll()
    {
        return await _db.Set<T>().ToListAsync();
    }
    
    public async Task Add(T item)
    {
        item.CreatedBy = GetCurrentUser();
        item.UpdatedBy = GetCurrentUser(); 
        await _db.Set<T>().AddAsync(item);
        await _db.SaveChangesAsync();
    }

    public async Task AddRange(List<T> list)
    {
        foreach (var item in list)
        {
            item.CreatedBy = GetCurrentUser();
            item.UpdatedBy = GetCurrentUser(); 
        }
        await _db.Set<T>().AddRangeAsync(list);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(T item)
    {
      
        item.Deleted = true;
        item.DeletedBy = GetCurrentUser();
        await Save();
    }

    public async Task DeleteRange(List<T> list)
    {
        foreach (T item in list)
        {
            await Delete(item);
        }
    }

    public async Task Update(T item)
    {

        item.UpdatedBy = GetCurrentUser();
        T? unchahgedEntity = await Find(item.Id);
        _db.Entry(unchahgedEntity).CurrentValues.SetValues(item);
        await Save();
    }

    public async Task UpdateRange(List<T> list)
    {
        foreach (T item in list)
        {
            item.UpdatedBy = GetCurrentUser();
            await Update(item);
        }
    }

    public async Task Destroy(T item)
    {
        _db.Set<T>().Remove(item);
        await Save();
    }

    public async  Task DestroyRange(List<T> list)
    {
        _db.Set<T>().RemoveRange(list);
        await Save();
    }

    public async Task<List<T>> Where(Expression<Func<T, bool>> exp)
    {
        return await _db.Set<T>().Where(exp).ToListAsync();
    }

    public async Task<bool> Any(Expression<Func<T, bool>> exp)
    {
        return await _db.Set<T>().AnyAsync(exp);
    }

    public async Task<T> FirstOrDefault(Expression<Func<T, bool>> exp)
    {
        return _db.Set<T>().FirstOrDefault(exp);
    }

    public async Task<object> Select(Expression<Func<T, object>> exp)
    {
        return _db.Set<T>().Select(exp);
    }

    public async Task<IQueryable<X>> Select<X>(Expression<Func<T, X>> exp)
    {
        return _db.Set<T>().Select(exp);
    }

    public async Task<T?> Find(int id)
    {
        return _db.Set<T>().FirstOrDefault(x => x.Id == id);
    }

    private string GetCurrentUser()
    {
        return "Admin"; 
    }
    
}