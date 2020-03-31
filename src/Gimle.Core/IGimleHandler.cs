using System.Threading.Tasks;
using Gimle.FromSlack;

namespace Gimle.Core
{
    public interface IGimleHandler
    {
        Task HandleAsync(SlackPayloadRequest request);
    }
}