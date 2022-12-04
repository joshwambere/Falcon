using Searching.Domain.Entities;
using Searching.Infrastructure.Data.Contexts;

namespace Searching.Infrastructure.Data.Repositories.Users;

public class UserRepository : GenericRepository<User>
{
    public UserRepository(DatabaseContext dbContext) : base(dbContext)
    {
    }
}
