using Newtonsoft.Json;

namespace Slack.Client.Models.SlackApi
{
    public class Member
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("team_id")]
        public string TeamId { get; set; }
        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("is_bot")]
        public bool IsBot { get; set; }
        [JsonProperty("updated")]
        public int Updated { get; set; }
        [JsonProperty("profile")]
        public Profile Profile { get; set; }
    }
}