using Searching.Infrastructure.Data;

namespace Searching.Management.Api.Services;

public class BaseService
{
    public BaseService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    protected internal IUnitOfWork UnitOfWork { get; }
}