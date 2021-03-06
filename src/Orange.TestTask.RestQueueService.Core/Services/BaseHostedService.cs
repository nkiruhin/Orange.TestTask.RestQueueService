using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Orange.TestTask.RestQueueService.Core.Services
{
    /// <summary>
    /// Base hosted app service
    /// </summary>
    public abstract class BaseHostedService : IHostedService
    {
        private readonly IServiceScope _serviceScope;

        protected readonly ILogger Logger;
        protected readonly IServiceProvider ServiceProvider;

        protected abstract Task StartAsyncCritical(CancellationToken cancellationToken);

        protected BaseHostedService(ILogger logger, IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScope = serviceScopeFactory.CreateScope();

            Logger = logger;
            ServiceProvider = _serviceScope.ServiceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                await StartAsyncCritical(cancellationToken);
            }
            catch (Exception exception)
            {
                FatalExit(exception);
            }
        }

        public virtual Task StopAsync(CancellationToken cancellationToken)
        {
            _serviceScope.Dispose();
            return Task.CompletedTask;
        }

        private void FatalExit(Exception exception)
        {
            Console.WriteLine($"Critical application hosted service error in {GetType().Name}. Exception=[{exception}]");
            Logger.LogError(exception, $"Critical application hosted service error in {GetType().Name}");
            Environment.ExitCode = -1;
            ServiceProvider.GetRequiredService<IHostApplicationLifetime>().StopApplication();
        }
    }
}
