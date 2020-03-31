using Newtonsoft.Json;

namespace Slack.Client.Models.SlackApi
{
    public class Channel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
