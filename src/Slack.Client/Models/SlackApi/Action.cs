using Newtonsoft.Json;

namespace Slack.Client.Models.SlackApi
{
    public class Action
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("type")]
        public ActionType Type { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("action_id")]
        public string ActionId { get; set; }
    }
}
