using Searching.Management.Api.Attributes;

namespace Searching.Management.Api.Extensions;

public static class ServicesExtensions
{
    public static void ExtendService(this IServiceCollection services)
    {
        var scopedServiceType = typeof(ScoppedServiceAttribute);
        var singletonServiceType = typeof(SingletonServiceAttribute);
        var assemblies = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(ass=>ass.GetTypes())
            .Where(type => type.IsDefined(scopedServiceType,false) || type.IsDefined(singletonServiceType, false))
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
                assemblyService.serviceTypes.ForEach(register =>services.AddSingleton(register, assemblyService.assignedType));
            }
        }
        
    }
}