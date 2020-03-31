using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.Client.Models.SlackApi;

namespace Gimle.FromSlack
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SlackViewRequest
    {
        [JsonProperty("blocks")]
        public ICollection<SlackBlockRequest> Blocks { get; set; }
        
        [JsonProperty("state")]
        public StateValues State { get; set; }
        
        [JsonProperty("callback_id")]
        public string CallbackId { get; set; }
    }
}