using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Searching.Infrastructure.Data.Interfaces;


public interface IDbContext:IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync();
    DbSet Set(Type entityType);
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    DbEntityEntry Entry(object entity);
    int SaveChanges();
}