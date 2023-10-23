using System.Net;
using Microsoft.AspNetCore.Mvc;
using Searching.Infrastructure.Exceptions;
using Searching.Management.Api.Attributes;

namespace Searching.Management.Api.Middlewares;

[AppMiddleWare]
public class ExceptionMiddleware : IMiddleware
{
    private readonly ILoggerFactory _logger;

    public ExceptionMiddleware(ILoggerFactory logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (DomainNotFoundException ex)
        {
            _logger.CreateLogger<ExceptionMiddleware>().LogError(ex, ex.Message);
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            await context.Response.WriteAsJsonAsync(new JsonResult(new
                { message = ex.Message, status = HttpStatusCode.NotFound }));
        }
        catch (DomainBadRequestException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsJsonAsync(new JsonResult(new
                { message = ex.Message, status = HttpStatusCode.BadRequest }));
        }
        catch (DomainConflictException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Conflict;
            await context.Response.WriteAsJsonAsync(new JsonResult(new
                { message = ex.Message, status = HttpStatusCode.Conflict }));
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync(new JsonResult(new
                { message = ex.Message, status = HttpStatusCode.InternalServerError }));
        }
    }
}