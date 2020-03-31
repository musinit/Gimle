using Newtonsoft.Json;

namespace Slack.Client.Models.SlackApi
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class BlockElement
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("text")]
        public BlockText Text { get; set; }
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
        [JsonProperty("alt_text")]
        public string AltText { get; set; }
        [JsonProperty("style")]
        public string Style { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("action_id")]
        public string ActionId { get; set; }
        [JsonProperty("placeholder")]
        public BlockText Placeholder { get; set; }
        [JsonProperty("initial_value")]
        public string InitialValue { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}