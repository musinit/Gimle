using Newtonsoft.Json;

namespace Slack.Client.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class UpdateViewRequest<T>
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        
        [JsonProperty("trigger_id")]
        public string TriggerId { get; set; }
        
        [JsonProperty("view_id")]
        public string ViewId { get; set; }
        
        [JsonProperty("view")]
        public T View { get; set; }
    }
}