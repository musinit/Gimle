using Newtonsoft.Json;

namespace Slack.Client.Models.SlackApi
{
    public class SlackUser : SlackResponse
    {
        [JsonProperty("id")]
        public string SlackId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("profile")]
        public Profile Profile { get; set; }
        
    }
}
