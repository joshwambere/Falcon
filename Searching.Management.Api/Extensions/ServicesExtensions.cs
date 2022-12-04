using Microsoft.EntityFrameworkCore;
using Searching.Management.Api.Attributes;
using Searching.Infrastructure.Data;
using Searching.Infrastructure.Data.Contexts;
using Searching.Infrastructure.Data.Interfaces;
using Searching.Infrastructure.Data.Repositories;
using Searching.Infrastructure.Data.Repositories.Users;
using Searching.Infrastructure.Data.UnitOfWork;



namespace Searching.Management.Api.Extensions;

public static class ServicesExtensions
{
    public static void ExtendService(this IServiceCollection services)
    {
        var scopedServiceType = typeof(ScoppedServiceAttribute);
        var singletonServiceType = typeof(SingletonServiceAttribute);
        var middlewareType = typeof(AppMiddleWareAttribute);
        var assemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(assembly=> assembly.FullName != null && assembly.FullName.Contains("Searching.Management"))
            .SelectMany(ass=>ass.GetTypes())
            .Where(type => type.IsDefined(scopedServiceType,false) || type.IsDefined(singletonServiceType, false) || type.IsDefined(middlewareType, false))
            .Select(a => new { assignedType = a, serviceTypes = a.GetInterfaces().ToList() }).ToList();
        
        
        /*
         * Add custom services based on attributes type
         */
        foreach (var assemblyService in assemblies) 
        {
            if (assemblyService.assignedType.IsDefined(scopedServiceType, false))
            {

                if (assemblyService.serviceTypes.Count > 0)
                {
                    foreach (var serviceType in assemblyService.serviceTypes)
                    {
                        services.AddScoped(serviceType, assemblyService.assignedType);
                    }
                }else
                {
                    services.AddScoped(assemblyService.assignedType);
                }
            }

            if (assemblyService.assignedType.IsDefined(singletonServiceType, false))
            {
                assemblyService.serviceTypes.ForEach(register => services.AddSingleton(register, assemblyService.assignedType));
            }
        }
        
    }
    
    /*
     * Add unitOfWork
     */
    public static IServiceCollection ExtendUnitOfWork(this IServiceCollection service)
    {
        return service.AddScoped<IUnitOfWork, UnitOfWork>();
    }
    
    public static IServiceCollection AddDatabase(this IServiceCollection service, IConfiguration configuration)
    {
        return service.AddDbContext<DatabaseContext>(option =>
            option.UseNpgsql(configuration.GetConnectionString("WebApiDb"),b=>b.MigrationsAssembly("Searching.Infrastructure")));
    }
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
            .AddScoped<UserRepository>();
    }
}