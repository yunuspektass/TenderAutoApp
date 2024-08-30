using System.Linq.Expressions;
using Core.Domain;
using Domain.Models;

namespace Business.GenericRepository.IntRep;

public interface IRepository<T> where T : BaseEntity
{
    //List COmmands

    Task<List<T>> GetAll();

    
    
   //Modify Commands

   Task Add(T item);

   Task AddRange(List<T> list);

   Task Delete(T item); // pasife çek

   Task DeleteRange(List<T> list);

   Task Update(T item);

   Task UpdateRange(List<T> list);

   Task Destroy(T item);

   Task DestroyRange(List<T> list);

   Task<List<T>> Where(Expression<Func<T, bool>> exp);

   Task<bool> Any(Expression<Func<T, bool>> exp);

   Task<T> FirstOrDefault(Expression<Func<T, bool>> exp);

   Task<object> Select(Expression<Func<T, object>> exp);

   Task<IQueryable<X>> Select<X>(Expression<Func<T, X>> exp);
   
   //Find Command
   Task<T?> Find(int id);



}