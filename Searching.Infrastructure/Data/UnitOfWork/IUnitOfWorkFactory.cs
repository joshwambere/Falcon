namespace Searching.Infrastructure.Data.UnitOfWork;

public interface IUnitOfWorkFactory
{
    IUnitOfWork Create();
    
}