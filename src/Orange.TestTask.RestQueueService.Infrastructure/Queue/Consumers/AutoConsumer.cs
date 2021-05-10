using EasyNetQ.AutoSubscribe;
using Microsoft.Extensions.Logging;
using Orange.TestTask.RestQueueService.Contracts.Models;
using System.Threading.Tasks;

namespace Orange.TestTask.RestQueueService.Infrastructure.Queue.Consumers
{
    internal class AutoConsumer : BaseConsumer<SimpleMessageResponse>
    {
        private readonly ILogger _logger;

        public AutoConsumer(ILogger logger) : base(logger)
        {
            _logger = logger;
        }

        [SubscriptionConfiguration(AutoDelete = true, PrefetchCount = 10)]
        [ForTopic("Topic.Foo")]
        protected override async Task ConsumeMessage(SimpleMessageResponse message) => _logger.LogInformation(message.ResponseText);
    }
}
