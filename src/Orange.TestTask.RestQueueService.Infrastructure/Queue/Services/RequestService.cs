using EasyNetQ;
using Microsoft.Extensions.Logging;
using Orange.TestTask.RestQueueService.Contracts.Models;
using Orange.TestTask.RestQueueService.Core.Commands;
using Orange.TestTask.RestQueueService.Core.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Orange.TestTask.RestQueueService.Infrastructure.Queue.Services
{
    public class RequestService : IQueueRequestService
    {
        private readonly IRpc _rpc;
        private readonly ILogger<RequestService> _logger;

        public RequestService(IRpc rpc, ILogger<RequestService> logger)
        {
            _rpc = rpc;
            _logger = logger;
        }

        public async Task<SimpleMessageResponse> SimpleMessageRequest(SimpleMessageParam request, CancellationToken cancellationToken)
        {
            request.CreateTimestamp = DateTimeOffset.Now;
            _logger.LogInformation($"Сообщение отправлено в очередь в { DateTimeOffset.Now }");
            return await _rpc.RequestAsync<SimpleMessageParam, SimpleMessageResponse>(request, cancellationToken);
        }
    }
}