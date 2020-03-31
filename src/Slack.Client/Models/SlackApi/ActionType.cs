using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Slack.Client.Models.SlackApi
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ActionType
    {
        button
    }
}
