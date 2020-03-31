using System;
using Slack.Client.Settings;

namespace Slack.Client
{ 
    public sealed class SlackClientConfiguration
    {
        private static SlackOptions options = new SlackOptions();

        public static SlackOptions Options
        {
            get => options;
            set => options = value;
        }

        private SlackClientConfiguration(){}
    }
}