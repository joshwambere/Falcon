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
            .Select(ass=>ass);
        
        
        /*
         * Add custom services based on attributes type
         */
        foreach (var assembly in assemblies) 
        {
            if (assembly.IsDefined(scopedServiceType, false))
            {
                services.AddScoped(assembly);
            }

            if (assembly.IsDefined(singletonServiceType, false))
            {
                services.AddSingleton(assembly);
            }
        }
        
    }
}