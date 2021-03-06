using System.Threading;
using System.Threading.Tasks;
using Orange.TestTask.RestQueueService.Core.Interfaces;
using MediatR;
using Orange.TestTask.RestQueueService.Contracts.Models;
using Orange.TestTask.RestQueueService.Core.Commands;

namespace Orange.TestTask.RestQueueService.Core.Handlers
{
    public class SendSimpleMessageHandler : IRequestHandler<SimpleMessageParam, SimpleMessageResponse>
    {
        private readonly IQueueRequestService _queue;

        public SendSimpleMessageHandler(IQueueRequestService queue)
        {
            _queue = queue;
        }

        public async Task<SimpleMessageResponse> Handle(SimpleMessageParam request, CancellationToken cancellationToken)
            => await _queue.SimpleMessageRequest(request, cancellationToken);
    }
}
