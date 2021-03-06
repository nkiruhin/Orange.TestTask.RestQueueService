using EasyNetQ.AutoSubscribe;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Orange.TestTask.RestQueueService.Infrastructure.Queue
{
    /// <summary>
    /// BaseConsumer
    /// </summary>
    public abstract class BaseConsumer<T>  : IConsumeAsync<T> where T : class
    {
        private readonly ILogger _logger;

        protected abstract Task ConsumeMessage(T message);
        protected BaseConsumer(ILogger logger)
        {
            _logger = logger;
        }

        public Task ConsumeAsync(T message, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Message recieved {0}", message);
            return Task.CompletedTask;
        }
    }
}
