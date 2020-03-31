using Newtonsoft.Json;

namespace Slack.Client.Models.SlackApi
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class BlockText
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}