using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using Slack.Client.Settings;

namespace Slack.Client
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddSlackClient(this IServiceCollection services, 
            [NotNull] Action<SlackOptions> options)
        {
            var slackOptions = new SlackOptions();
            options(slackOptions);
            SlackClientConfiguration.Options = slackOptions;
            services.AddHttpClient<ISlackClient, SlackClient>(client => {
                client.BaseAddress = new Uri(slackOptions.SlackApi);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", slackOptions.AppToken);
                });
            services.AddTransient<ISlackClient, SlackClient>();

            return services;
        }
    }
}
