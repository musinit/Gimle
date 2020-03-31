using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slack.Client.Models.SlackApi;

namespace Gimle.FromSlack
{
    public class SlackActionRequest
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("action_id")]
        public string ActionId { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("selected_option")]
        public BlockOption SelectedOption { get; set; }
        [JsonProperty("selected_options")]
        public BlockOption[] SelectedOptions { get; set; }
    }
}