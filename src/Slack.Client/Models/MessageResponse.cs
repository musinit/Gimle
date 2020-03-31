using Newtonsoft.Json;
using Slack.Client.Models.SlackApi;

namespace Slack.Client.Models
{
    public class MessageResponse
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("blocks")]
        public Block[] Blocks { get; set; }

        [JsonProperty("replace_original")] public string ReplaceOriginal = "true";
    }
}