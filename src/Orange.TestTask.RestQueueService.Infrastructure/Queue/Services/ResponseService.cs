using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Orange.TestTask.RestQueueService.Contracts.Models;
using Orange.TestTask.RestQueueService.Core.Commands;
using Orange.TestTask.RestQueueService.Core.Interfaces;

namespace Orange.TestTask.RestQueueService.Infrastructure.Queue.Services
{
    public class ResponseService : IQueueResponseService
    {
        private readonly ILogger<ResponseService> _logger;

        public ResponseService(ILogger<ResponseService> logger)
        {
            _logger = logger;
        }

        public async Task<SimpleMessageResponse> CreateSimpleMessageResponse(SimpleMessageParam request)
        {
            _logger.LogInformation($"Сообщение получено из очереди в { DateTimeOffset.Now }");
            var response = new SimpleMessageResponse
            {
                ResponseText = "Responding to " + request.Text,
                Timespam = DateTimeOffset.Now - request.CreateTimestamp
            };
            return await Task.FromResult(response);
        }
    }
}
