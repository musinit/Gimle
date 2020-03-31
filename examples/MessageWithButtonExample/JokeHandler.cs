using System.Threading.Tasks;
using Gimle.Core;
using Gimle.FromSlack;

namespace GimleApiExample
{
    public class JokeAction : IGimleHandler
    {
        private readonly GimleClient _gimleClient;

        public JokeAction(GimleClient gimleClient) => _gimleClient = gimleClient;
        public async Task HandleAsync(SlackPayloadRequest request)
        {
            await _gimleClient.SendSlackMessageAsync("U631X4HNY", "joke");
        }
    }
}