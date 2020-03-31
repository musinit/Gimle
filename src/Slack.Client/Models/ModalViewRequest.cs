using Newtonsoft.Json;
using Slack.Client.Models.SlackApi;

namespace Slack.Client.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ModalViewRequest
    {
        [JsonProperty("type")]
        public string type { get; set; }
        [JsonProperty("callback_id")]
        public string CallbackId { get; set; }
        [JsonProperty("submit")]
        public BlockText Submit { get; set; }
        [JsonProperty("close")]
        public BlockText Close { get; set; }
        [JsonProperty("title")]
        public BlockText Title { get; set; }
        [JsonProperty("blocks")]
        public Block[] blocks { get; set; }
    }
}