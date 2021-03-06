using Orange.TestTask.RestQueueService.Contracts.Models;
using System.Threading.Tasks;
using Orange.TestTask.RestQueueService.Core.Commands;

namespace Orange.TestTask.RestQueueService.Core.Interfaces
{
    public interface IQueueResponseService
    {
        Task<SimpleMessageResponse> CreateSimpleMessageResponse(SimpleMessageParam request);
    }
}
