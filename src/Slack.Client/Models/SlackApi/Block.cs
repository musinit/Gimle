using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Slack.Client.Models.SlackApi
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Block
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BlockTypeEnum Type { get; set; }
        [JsonProperty("text")]
        public BlockText Text { get; set; }
        [JsonProperty("label")]
        public BlockText Label { get; set; }
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
        [JsonProperty("alt_text")]
        public string AltText { get; set; }
        [JsonProperty("accessory")]
        public BlockAccessory Accessory { get; set; }
        [JsonProperty("elements")]
        public BlockElement[] Elements { get; set; }
        [JsonProperty("element")]
        public BlockElement Element { get; set; }
        [JsonProperty("action_id")]
        public string ActionId { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("options")]
        public BlockOption[] Options { get; set; }
    }
}