using System.Threading.Tasks;
using Gimle.Core;
using Gimle.FromSlack;

namespace GimleApiExample
{
    public class GoodMoodHandler : IGimleHandler
    {
        private readonly GimleClient _gimleClient;

        public GoodMoodHandler(GimleClient gimleClient) => _gimleClient = gimleClient;
        public async Task HandleAsync(SlackPayloadRequest request)
        {
            await _gimleClient.SendResponseMessageAsync(request.ResponseUrl, "good_mood");
        }
    }
}