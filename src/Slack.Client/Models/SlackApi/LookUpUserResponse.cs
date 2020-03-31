using Newtonsoft.Json;

namespace Slack.Client.Models.SlackApi
{
    public class LookUpUserResponse : SlackResponse
    {
        [JsonProperty("user")]
        public SlackUser User { get; set; }
    }
}
