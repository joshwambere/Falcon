using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Searching.Domain.Base;
using Searching.Infrastructure.Data.Contexts;
using Searching.Infrastructure.Data.Interfaces;

namespace Searching.Infrastructure.Data.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly DbSet<T> _dbSet;

    public GenericRepository(DatabaseContext dbContext)
    {
        _dbSet = dbContext.Set<T>();
    }
    

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public Task<bool> DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        return Task.FromResult(true);
    }

    public Task<T?> GetAsync(Expression<Func<T, bool>> expression)
    {
        return _dbSet.FirstOrDefaultAsync(expression);
    }

    public Task<List<T>> ListAsync(Expression<Func<T, bool>> expression)
    {
        return _dbSet.Where(expression).ToListAsync();
    }

    public Task<T> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        return Task.FromResult(entity);
    }
}