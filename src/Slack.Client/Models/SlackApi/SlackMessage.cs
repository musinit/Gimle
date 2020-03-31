using Newtonsoft.Json;

namespace Slack.Client.Models.SlackApi
{
    public class SlackMessage
    {
        [JsonProperty("callback_id")]
        public string CallbackId { get; set; }
        [JsonProperty("channel")]
        public string Channel { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("attachments")]
        public Attachment[] Attachments { get; set; }
        [JsonProperty("blocks")]
        public Block[] Blocks { get; set; }
        
        [JsonProperty("response_url")]
        public string ResponseUrl { get; set; }
    }
}
