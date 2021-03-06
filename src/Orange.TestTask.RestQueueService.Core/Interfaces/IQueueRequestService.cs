using Orange.TestTask.RestQueueService.Contracts.Models;
using System.Threading;
using System.Threading.Tasks;
using Orange.TestTask.RestQueueService.Core.Commands;

namespace Orange.TestTask.RestQueueService.Core.Interfaces
{
    public interface IQueueRequestService
    {
        Task<SimpleMessageResponse> SimpleMessageRequest(SimpleMessageParam request, CancellationToken cancellationToken);
    }
}
