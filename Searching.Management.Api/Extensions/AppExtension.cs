using Searching.Management.Api.Middlewares;

namespace Searching.Management.Api.Extensions;

public static class AppExtension
{
    
    public static void RegisterMiddleware( this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}