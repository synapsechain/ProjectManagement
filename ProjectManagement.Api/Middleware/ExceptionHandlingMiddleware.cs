using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ProjectManagement.Api.Exceptions;

namespace ProjectManagement.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext).ConfigureAwait(false);
            }
            catch (NotFoundException nfe)
            {
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                await httpContext.Response.WriteAsync(nfe.Message).ConfigureAwait(false);
            }
        }
    }
}
