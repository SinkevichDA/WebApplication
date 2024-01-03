using Microsoft.AspNetCore.Builder;
using WebApplication7.Middleware;

namespace WebApplication7.Extensions
{
    public static class AppExtensions
    {
        public static IApplicationBuilder UseFileLogging(this
        IApplicationBuilder app)
        => app.UseMiddleware<LogMiddleware>();
    }
}