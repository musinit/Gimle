using System.Threading;
using System.Threading.Tasks;
using Slack.Client.Models;
using Slack.Client.Models.SlackApi;

namespace Slack.Client
{
    public interface ISlackClient
    {
        Task<bool> SendMessageAsync(SendMessageRequest request,
            CancellationToken cancellationToken = default);
        
        Task SendResponseMessageAsync(string responseUrl, Block[] blocks, CancellationToken cancellationToken = default);
        
        Task<SlackResponse> UpdateViewAsync<T>(UpdateViewRequest<T> request, string requestUrl = "views.publish", 
            CancellationToken cancellationToken = default);
        
        Task<SlackUser> GetUserIfExistAsync(string email);
    }
}
