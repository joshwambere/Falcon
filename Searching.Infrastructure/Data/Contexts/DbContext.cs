using Microsoft.EntityFrameworkCore;
using Searching.Domain.Base;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;


namespace Searching.Infrastructure.Data.Contexts;

public class DatabaseContext: DbContext
{

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var assemblyFromClass = (from asm in AppDomain.CurrentDomain.GetAssemblies()
            from type in asm.GetTypes()
            where type.IsSubclassOf(typeof(BaseEntity))
            select type).ToList();

        foreach (var entity in assemblyFromClass)
        {
            modelBuilder.Entity(entity);
        }
    }
}