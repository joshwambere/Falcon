using System.Linq.Expressions;

namespace Searching.Infrastructure.Data.Interfaces;


public interface IGenericRepository<T>
{
    Task<T> AddAsync(T entity);

    Task<T> UpdateAsync(T entity);

    Task<bool> DeleteAsync(T entity);

    Task<T?> GetAsync(Expression<Func<T, bool>> expression);

    Task<List<T>> ListAsync(Expression<Func<T, bool>> expression);
}