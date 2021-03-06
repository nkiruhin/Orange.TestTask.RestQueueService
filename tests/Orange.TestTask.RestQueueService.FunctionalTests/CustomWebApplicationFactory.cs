using System;
using System.Linq;
using JetBrains.Annotations;
using Orange.TestTask.RestQueueService.UnitTests;
using Orange.TestTask.RestQueueService.Web;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orange.TestTask.RestQueueService.Core.Interfaces;
using Orange.TestTask.RestQueueService.Infrastructure.Queue.Services;
using Orange.TestTask.RestQueueService.Infrastructure;

namespace Orange.TestTask.RestQueueService.FunctionalTests
{
    [UsedImplicitly]
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var host = builder.Build();


            // Get service provider.
            var serviceProvider = host.Services;


            host.Start();
            return host;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
                .UseSolutionRelativeContentRoot("src/Orange.TestTask.RestQueueService.Web")
                .ConfigureServices(services =>
                {
                    services.AddScoped<IMediator, NoOpMediator>();
                });
        }
    }
}