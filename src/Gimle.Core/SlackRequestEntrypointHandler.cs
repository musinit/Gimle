using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gimle.FromSlack;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Gimle.Core
{
    public class SlackRequestEntrypointHandler
    {
        public async Task Process(string rowPayload, IServiceProvider serviceProvider)
        {
            var request = JsonConvert.DeserializeObject<SlackPayloadRequest>(rowPayload);
            // Trying to get the key of action, if it's null, than Modal submit it taking place,
            // and we need callbackId value
            var actionId = request.SlackActions?.Select(a => a.ActionId).FirstOrDefault() ??
                request.View.CallbackId;
            var handlerType = GimleOptions.ActionHandlers[actionId];
            if (handlerType == null) throw new KeyNotFoundException(nameof(actionId));
            var handlerObject = (IGimleHandler)ActivatorUtilities.CreateInstance(serviceProvider, handlerType);
            await handlerObject.HandleAsync(request);
        }
    }
}