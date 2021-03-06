using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Orange.TestTask.RestQueueService.Contracts.Models;
using Orange.TestTask.RestQueueService.Core.Commands;

namespace Orange.TestTask.RestQueueService.UnitTests
{
    public class NoOpMediator : IMediator
    {
        public Task Publish(object notification, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
        {
            return Task.CompletedTask;
        }

        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            if (request is SimpleMessageParam simpleMessageParam)
            {
                var res = new SimpleMessageResponse { ResponseText = simpleMessageParam.Text, Timespam = DateTime.Now - simpleMessageParam.CreateTimestamp };
                if (res is TResponse response)
                {
                    return Task.FromResult(response);
                }
            }
            return Task.FromResult<TResponse>(default);
        }

        public Task<object> Send(object request, CancellationToken cancellationToken = default)
        {
            return Task.FromResult<object>(default);
        }
    }
}
