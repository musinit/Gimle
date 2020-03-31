using Newtonsoft.Json;

namespace Slack.Client.Models.SlackApi
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class BlockAccessory
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
        [JsonProperty("text")]
        public BlockText Text { get; set; }
        [JsonProperty("alt_text")]
        public string AltText { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("action_id")]
        public string ActionId { get; set; }
        [JsonProperty("options")]
        public BlockOption[] Options { get; set; }
        [JsonProperty("initial_option")]
        public BlockOption InitialOption { get; set; }
        [JsonProperty("initial_options")]
        public BlockOption[] InitialOptions { get; set; }
        [JsonProperty("min_query_length")]
        public int? MinQueryLength { get; set; }
        [JsonProperty("max_selected_items")]
        public int? MaxSelectedItems { get; set; }
    }
}