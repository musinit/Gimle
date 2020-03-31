using Newtonsoft.Json;

namespace Slack.Client.Models.SlackApi
{
    public class OpenChannelResponse : SlackResponse
    {
        [JsonProperty("channel")]
        public SlackChannel Channel { get; set; }
    }
}
