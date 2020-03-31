using Newtonsoft.Json;
using Slack.Client.Models.SlackApi;

namespace Slack.Client.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class MessageViewRequest
    {
        [JsonProperty("slackId")]
        public string SlackId { get; set; }

        /// <summary>
        /// Id Acion, который заведен в Slack
        /// Пример - https://api.slack.com/apps/AEWM1NWEB/interactive-messages?
        /// </summary>
        [JsonProperty("callback_id")]
        public string CallbackId { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Приложение к сообщению (кнопка/меню/картинка)
        /// </summary>
        [JsonProperty("attachments")]
        public Attachment[] Attachments { get; set; }
        
        [JsonProperty("blocks")]
        public Block[] Blocks { get; set; }
    }
}