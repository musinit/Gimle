using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.Client.Models.SlackApi;

namespace Gimle.FromSlack
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SlackPayloadRequest
    {
        [JsonProperty("type")]
        public SlackPayloadRequestTypeEnum Type { get; set; }
        
        [JsonProperty("user")]
        public SlackUser SlackUser { get; set; }
        
        [JsonProperty("view")]
        public SlackViewRequest View { get; set; }

        [JsonProperty("actions")]
        public SlackActionRequest[] SlackActions { get; set; }
        
        [JsonProperty("trigger_id")]
        public string TriggerId { get; set; }
        [JsonProperty("response_url")]
        public string ResponseUrl { get; set; }
        [JsonProperty("action_id")]
        public SlackActionIdEnum ActionId { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}