using System.Threading;
using System.Threading.Tasks;
using Slack.Client;
using Slack.Client.Models;
using Gimle.Core.Utils;
using Slack.Client.Models.SlackApi;

namespace Gimle.Core
{
    public class GimleClient
    {
        private readonly ISlackClient _slackClient;

        public GimleClient(ISlackClient slackClient) => _slackClient = slackClient;
        
        public async Task<bool> SendSlackMessageAsync(string slackId, 
            string templateId, ReplaceValue[] replaceValues=null, CancellationToken cancellationToken = default)
        {
            var blocks = CommonHelper.DeserializeArray(templateId, replaceValues);
            var request = new SendMessageRequest{SlackId = slackId, Blocks = blocks};
            return await _slackClient.SendMessageAsync(request, cancellationToken);
        }

        public async Task SendResponseMessageAsync(string url, string templateId,
            ReplaceValue[] replaceValues = null, CancellationToken cancellationToken = default)
        {
            var blocks = CommonHelper.DeserializeArray(templateId, replaceValues);
            await _slackClient.SendResponseMessageAsync(url, blocks, cancellationToken);
        }

        public async Task UpdateHomeAsync(string slackId, string templateId,
            ReplaceValue[] replaceValues = null, CancellationToken cancellationToken = default)
        {
            var blocks = CommonHelper.DeserializeArray(templateId, replaceValues);
            var updateViewRequest = new UpdateViewRequest<BasicViewRequest> {UserId = slackId};
            var viewRequestBody = new BasicViewRequest();
            viewRequestBody.type = "home";
            viewRequestBody.blocks = blocks;
            viewRequestBody.CallbackId = "update_home";
            updateViewRequest.View = viewRequestBody;
            await _slackClient.UpdateViewAsync(updateViewRequest, cancellationToken: cancellationToken);
        }
        
        public async Task OpenModalAsync(string slackId, string triggerId, string templateId, string callbackId,
            string title, string submit = "Save", string close = "Close",
            ReplaceValue[] replaceValues = null, CancellationToken cancellationToken = default)
        {
            var blocks = CommonHelper.DeserializeArray(templateId, replaceValues);
            var updateViewRequest = new UpdateViewRequest<ModalViewRequest>
            {
                UserId = slackId,
                TriggerId = triggerId
            };
            var viewRequestBody = new ModalViewRequest();
            viewRequestBody.type = "modal";
            viewRequestBody.CallbackId = callbackId;
            viewRequestBody.blocks = blocks;
            viewRequestBody.Title = new BlockText {Text = title, Type = "plain_text"};
            viewRequestBody.Close = new BlockText {Text = close, Type = "plain_text"};
            viewRequestBody.Submit = new BlockText {Text = submit, Type = "plain_text"};
            updateViewRequest.View = viewRequestBody;
            await _slackClient.UpdateViewAsync(updateViewRequest, "views.open", cancellationToken: cancellationToken);
        }
    }
}