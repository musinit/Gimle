using System.Collections.Generic;
using System.Threading.Tasks;
using Gimle.Core;
using Gimle.FromSlack;
using Gimle.Core.Extensions;
using Gimle.Core.Utils;

namespace ModalExample
{
    public class SaveMeaningOfLifeHandler : IGimleHandler
    {
        private readonly GimleClient _gimleClient;

        public SaveMeaningOfLifeHandler(GimleClient gimleClient) => _gimleClient = gimleClient;
        public async Task HandleAsync(SlackPayloadRequest request)
        {
            var meaningOfLife = request.View.State.GetModalValue("meaning_of_life_field");
            await _gimleClient.UpdateHomeAsync("U631X4HNY", "profile", new []
            {
                new ReplaceValue("[@meaning_of_life]", meaningOfLife, true) 
            });
        }
    }
}