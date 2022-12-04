using Searching.Infrastructure.Data.Interfaces;
using Searching.Domain.Base;
namespace Searching.Infrastructure.Data;

 public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

        IGenericRepository<T> AsyncRepository<T>() where T : BaseEntity;
    }