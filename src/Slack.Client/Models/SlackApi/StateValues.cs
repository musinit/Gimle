using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.Client.Models.SlackApi
{
    public class StateValues
    {
        [JsonProperty("values")]
        public Dictionary<string, Dictionary<string, ModalValue>> Values{ get; set; }
    }
}