using Gimle.Core.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Gimle.Core.Extensions
{
    public static class AppBuilderExtension
    {
        public static IApplicationBuilder UseGimle(
            this IApplicationBuilder builder, string route = "slack-requests")
        {
            return builder.UseMiddleware<SlackRequestsMiddleware>(route);
        }
    }
}