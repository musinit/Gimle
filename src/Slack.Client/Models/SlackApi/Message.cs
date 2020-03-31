using Newtonsoft.Json;

namespace Slack.Client.Models.SlackApi
{
    public class Message
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("user")]
        public string User { get; set; }
        [JsonProperty("ts")]
        public string Ts { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
