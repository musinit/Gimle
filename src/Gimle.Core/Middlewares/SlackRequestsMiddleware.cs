using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Gimle.Core.Middlewares
{
    public class SlackRequestsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _slackRequestRoute;
        private SlackRequestEntrypointHandler _slackRequestEntrypointHandler;
        private IServiceProvider _serviceProvider;

        public SlackRequestsMiddleware(RequestDelegate next, 
            string slackRequestRoute, SlackRequestEntrypointHandler slackRequestEntrypointHandler,
            IServiceProvider serviceProvider)
        {
            _next = next;
            _slackRequestRoute = slackRequestRoute;
            _slackRequestEntrypointHandler = slackRequestEntrypointHandler;
            _serviceProvider = serviceProvider;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.Value.Contains(_slackRequestRoute))
            {
                await _slackRequestEntrypointHandler.Process(context.Request.Form["payload"], 
                    _serviceProvider);
            }
            
            await _next(context);
        }
    }
}