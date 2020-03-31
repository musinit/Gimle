using Newtonsoft.Json;

namespace Slack.Client.Models.SlackApi
{
    public class Attachment
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("fallback")]
        public string Fallback { get; set; }
        [JsonProperty("callback_id")]
        public string CallbackId { get; set; }
        [JsonProperty("color")]
        public string Color { get; set; }
        [JsonProperty("attachment_type")]
        public string AttachmentType { get; set; }
        [JsonProperty("actions")]
        public Action[] Actions { get; set; }
        
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
        
        [JsonProperty("thumb_url")]
        public string ThumbUrl { get; set; }
        
        [JsonProperty("footer")]
        public string Footer { get; set; }
        
        [JsonProperty("footer_icon")]
        public string FooterIcon { get; set; }
        
    }
}
