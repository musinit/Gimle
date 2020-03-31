using Newtonsoft.Json;
using Slack.Client.Models.SlackApi;

namespace Slack.Client.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SendResponseMessageRequest
    {
        /// <summary>
        /// id пользователя, которому будет отправлено сообщение
        /// </summary>
        [JsonProperty("slackId")]
        public string SlackId { get; set; }
        
        [JsonProperty("blocks")]
        public Block[] Blocks { get; set; }

        [JsonProperty("response_url")]
        public string ResponseUrl { get; set; }
    }
}
