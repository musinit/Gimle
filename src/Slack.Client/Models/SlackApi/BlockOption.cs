using Newtonsoft.Json;

namespace Slack.Client.Models.SlackApi
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class BlockOption
    {
        [JsonProperty("text")]
        public BlockText Text { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}