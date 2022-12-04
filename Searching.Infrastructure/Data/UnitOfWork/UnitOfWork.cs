using Searching.Domain.Base;
using Searching.Infrastructure.Data.Contexts;
using Searching.Infrastructure.Data.Interfaces;
using Searching.Infrastructure.Data.Repositories;

namespace Searching.Infrastructure.Data.UnitOfWork;

public class UnitOfWork:IUnitOfWork
{
    private readonly DatabaseContext _context;

    public UnitOfWork(DatabaseContext context)
    {
        _context = context;
        if (Extensions.Extensions.TestConnection(_context))
        {
            Console.WriteLine("Database connection Opened");
        }
        else
        {
            Console.WriteLine("Connection Failed");
        }

    }
    

    public IGenericRepository<T> AsyncRepository<T>() where T : BaseEntity
    {
        return new GenericRepository<T>(_context);
    }

    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}
