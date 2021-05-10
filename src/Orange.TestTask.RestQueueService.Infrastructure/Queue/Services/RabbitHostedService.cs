using EasyNetQ;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Orange.TestTask.RestQueueService.Contracts.Models;
using Orange.TestTask.RestQueueService.Core.Interfaces;
using Orange.TestTask.RestQueueService.Core.Services;
using System.Threading;
using System.Threading.Tasks;
using Orange.TestTask.RestQueueService.Core.Commands;
using System;
using EasyNetQ.AutoSubscribe;
using System.Reflection;

namespace Orange.TestTask.RestQueueService.Infrastructure.Queue.Services
{
    /// <summary>
    /// Сервис-хост для прослушивания очередей
    /// </summary>
    public class RabbitHostedService : BaseHostedService
    {
        private readonly IBus _bus;
        private readonly IQueueResponseService _responseService;
        private readonly AutoSubscriber _subscriber;

        public RabbitHostedService(ILogger<RabbitHostedService> logger, IServiceScopeFactory serviceScopeFactory, IBus bus, IQueueResponseService responseService)
            : base(logger, serviceScopeFactory)
        {
            _bus = bus;
            _responseService = responseService;
            _subscriber = new AutoSubscriber(_bus, Assembly.GetExecutingAssembly().GetName().Name);
        }

        protected override async Task StartAsyncCritical(CancellationToken cancellationToken)
        {
            await _bus.Rpc.RespondAsync<SimpleMessageParam, SimpleMessageResponse>(_responseService.CreateSimpleMessageResponse, cancellationToken);
            await _subscriber.SubscribeAsync(Assembly.GetExecutingAssembly().GetTypes(), cancellationToken);            
        }

        private void SubConfigure(ISubscriptionConfiguration obj) => obj.WithTopic("test");
        private Task OnSimpleMessageHandler(SimpleMessageParam arg1, CancellationToken arg2) => throw new NotImplementedException();

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await base.StopAsync(cancellationToken);
        }
    }
}
