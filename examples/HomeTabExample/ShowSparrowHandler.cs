using System.Threading.Tasks;
using Gimle.Core;
using Gimle.FromSlack;

namespace HomeTabExample
{
    public class ShowSparrowHandler : IGimleHandler
    {
        private readonly GimleClient _gimleClient;

        public ShowSparrowHandler(GimleClient gimleClient) => _gimleClient = gimleClient;
        public async Task HandleAsync(SlackPayloadRequest request)
        {
            await _gimleClient.UpdateHomeAsync("U631X4HNY", "profile_with_sparrow");
        }
    }
}