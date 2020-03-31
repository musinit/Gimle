using System;
using System.Collections.Concurrent;

namespace Gimle.Core
{
    public class GimleOptions
    {
        public static ConcurrentDictionary<string, Type> ActionHandlers = new ConcurrentDictionary<string, Type>();
        public void AddHandler(string actionId, Type handlerType)
        {
            ActionHandlers.AddOrUpdate(actionId,
                value => ActionHandlers[value] = handlerType,
                (value, _) => ActionHandlers[actionId] = handlerType);
        }
    }
}