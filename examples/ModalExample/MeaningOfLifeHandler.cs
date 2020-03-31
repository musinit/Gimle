using System.Threading.Tasks;
using Gimle.Core;
using Gimle.FromSlack;

namespace ModalExample
{
    public class MeaningOfLifeHandler : IGimleHandler
    {
        private readonly GimleClient _gimleClient;

        public MeaningOfLifeHandler(GimleClient gimleClient) => _gimleClient = gimleClient;
        public async Task HandleAsync(SlackPayloadRequest request)
        {
            var slackId = "U631X4HNY"; // Hard coded users just for example
            await _gimleClient.OpenModalAsync(slackId, request.TriggerId,
                "meaning_of_life_modal", "meaning_of_life_modal", 
                "Meaning of life");

        }
    }
}