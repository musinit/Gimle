using System.Collections.Generic;

namespace Slack.Client.Models.SlackApi
{
    public class StateValue
    {
        public Dictionary<string, ModalValue> Value { get; set; }
    }
}