using Newtonsoft.Json;

namespace Slack.Client.Models.SlackApi
{
    public class Profile
    {
        [JsonProperty("skype")]
        public string Skype { get; set; }
        [JsonProperty("real_name_normalized")]
        public string RealNameNormalized { get; set; }
        [JsonProperty("image_original")]
        public string ImageOriginal { get; set; }
        [JsonProperty("image_24")]
        public string Image24 { get; set; }
        [JsonProperty("image_48")]
        public string Image48 { get; set; }
        [JsonProperty("image_512")]
        public string Image512 { get; set; }
    }
}