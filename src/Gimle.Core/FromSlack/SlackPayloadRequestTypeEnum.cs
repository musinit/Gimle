using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Gimle.FromSlack
{
    public enum SlackPayloadRequestTypeEnum
    {
        block_actions,
        view_submission,
        static_select,
        block_suggestion,
        multi_external_select
    }
}