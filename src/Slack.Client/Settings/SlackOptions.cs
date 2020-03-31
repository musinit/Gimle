
namespace Slack.Client.Settings
{
    public class SlackOptions
    {
        public string SlackApi { get; set; }

        public string AppToken { get; set; }
        
        public bool IsTest { get; set; }
        public string TestChannelId { get; set; }
    }
}
