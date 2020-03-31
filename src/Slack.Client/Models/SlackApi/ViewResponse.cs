using Newtonsoft.Json;

namespace Slack.Client.Models.SlackApi
{
    public class ViewResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}