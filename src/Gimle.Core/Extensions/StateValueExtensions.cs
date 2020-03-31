using System.Linq;
using Slack.Client.Models.SlackApi;

namespace Gimle.Core.Extensions
{
    public static class StateValueExtensions
    {
        public static string GetModalValue(this StateValues source, string key)
        {
            return source.Values.Values.FirstOrDefault(v => v.ContainsKey(key)).Values.First().Value;
        }
    }
}