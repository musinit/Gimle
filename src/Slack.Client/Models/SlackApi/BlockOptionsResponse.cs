using Newtonsoft.Json;

namespace Slack.Client.Models.SlackApi
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class BlockOptionsResponse
    {
        [JsonProperty("options")]
        public BlockOption[] Options { get; set; }
    }
}