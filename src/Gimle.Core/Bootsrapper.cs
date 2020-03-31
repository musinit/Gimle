using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Slack.Client;

namespace Gimle.Core
{
    public static class Bootsrapper
    {
        public static void AddGimleLib(this IServiceCollection services, 
            [NotNull] string appToken, [NotNull] string slackApi,
            Action<GimleOptions> options = null)
        {
            services.AddSlackClient(options =>
            {
                options.AppToken = appToken;
                options.SlackApi = slackApi;
                options.IsTest = false;
                options.TestChannelId = "test_channel_id_here";

            });
            services.AddTransient<GimleClient>();
            services.AddTransient<SlackRequestEntrypointHandler>();
            
            var gimleOptions = new GimleOptions();
            options(gimleOptions);
        }
        
    }
}