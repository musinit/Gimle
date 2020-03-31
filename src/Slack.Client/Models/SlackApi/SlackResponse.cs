using Newtonsoft.Json;

namespace Slack.Client.Models.SlackApi
{
    public class SlackResponse
    {
        [JsonProperty("ok")]
        public bool Ok { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
        
        [JsonProperty("view")]
        public ViewResponse ViewResponse { get; set; }
        
    }
}
