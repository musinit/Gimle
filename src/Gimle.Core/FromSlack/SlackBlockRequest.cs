using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.Client.Models.SlackApi;

namespace Gimle.FromSlack
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SlackBlockRequest
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("block_id")]
        public string BlockId { get; set; }
        [JsonProperty("elements")]
        public ICollection<SlackActionRequest> Elements { get; set; }
        [JsonProperty("trigger_id")]
        public string TriggerId { get; set; }
        [JsonProperty("text")]
        public BlockText Text { get; set; }
        [JsonProperty("accessory")]
        public BlockAccessory Accessory { get; set; }
    }
}