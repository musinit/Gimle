using Newtonsoft.Json;

namespace Slack.Client.Models.SlackApi
{
    public class SlackChannel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
