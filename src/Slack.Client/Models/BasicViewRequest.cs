using Newtonsoft.Json;
using Slack.Client.Models.SlackApi;

namespace Slack.Client.Models
{
    public class BasicViewRequest
    {
        [JsonProperty("type")]
        public string type { get; set; }
        [JsonProperty("blocks")]
        public Block[] blocks { get; set; }
        [JsonProperty("callback_id")]
        public string CallbackId { get; set; }
    }
}