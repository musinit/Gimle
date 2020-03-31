using Newtonsoft.Json;

namespace Slack.Client.Models.SlackApi
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ModalValue
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}