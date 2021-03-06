using Microsoft.Extensions.DependencyInjection;
using Orange.TestTask.RestQueueService.Core.Interfaces;
using Orange.TestTask.RestQueueService.Infrastructure.Queue.Services;
using System;

namespace Orange.TestTask.RestQueueService.Infrastructure
{
    public static class StartupSetup
    {

        /// <summary>
        /// Регистрация зависимостей уровня инфраструктуры
        /// </summary>
        /// <param name="serviceCollection">serviceCollection</param>
        /// <param name="infrastructureSettingsAction"></param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, Action<InfrastructureSettings> infrastructureSettingsAction)
        {
            var infrastructureSettings = new InfrastructureSettings();
            infrastructureSettingsAction?.Invoke(infrastructureSettings);
            serviceCollection.RegisterEasyNetQ(infrastructureSettings.QueueConnectionString);
            serviceCollection.AddHostedService<RabbitHostedService>();
            serviceCollection.AddSingleton(infrastructureSettings);
            serviceCollection.AddTransient<IQueueResponseService, ResponseService>();
            serviceCollection.AddTransient<IQueueRequestService, RequestService>();
            return serviceCollection;
        }
    }
}
