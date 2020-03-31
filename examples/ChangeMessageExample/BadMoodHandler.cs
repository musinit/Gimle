using System.Threading.Tasks;
using Gimle.Core;
using Gimle.FromSlack;

namespace GimleApiExample
{
    public class BadMoodHandler : IGimleHandler
    {
        private readonly GimleClient _gimleClient;

        public BadMoodHandler(GimleClient gimleClient) => _gimleClient = gimleClient;
        public async Task HandleAsync(SlackPayloadRequest request)
        {
            await _gimleClient.SendResponseMessageAsync(request.ResponseUrl, "bad_mood");
        }
    }
}