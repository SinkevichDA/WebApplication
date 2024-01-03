using Microsoft.AspNetCore.Http;

namespace WebApplication7.Extensions
{
    public static class RequestExtensions
    {
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            return request

            .Headers["x-requested-with"]
            .Equals("XMLHttpRequest");

        }
    }
}