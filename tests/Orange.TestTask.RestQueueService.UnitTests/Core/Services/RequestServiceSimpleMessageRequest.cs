using EasyNetQ;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Orange.TestTask.RestQueueService.Contracts.Models;
using Orange.TestTask.RestQueueService.Core.Commands;
using Orange.TestTask.RestQueueService.Infrastructure.Queue.Services;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Orange.TestTask.RestQueueService.UnitTests.Core.Services
{
    public class RequestServiceSimpleMessageRequest
    {
        private readonly IRpc _rpc;
        private readonly ILogger<RequestService> _logger;
        public RequestServiceSimpleMessageRequest()
        {
            _rpc = Substitute.For<IRpc>();
            _logger = Substitute.For<ILogger<RequestService>>();
        }

        [Fact]
        public async Task ReturnsNotFoundGivenNoRemainingItems()
        {
            //Arrange
            var request = new SimpleMessageParam("test");
            var mockResponse = new SimpleMessageResponse
            {
                Timespam = new TimeSpan(1000),
                ResponseText = "test"
            };
            _rpc.RequestAsync<SimpleMessageParam, SimpleMessageResponse>(Arg.Any<SimpleMessageParam>(), Arg.Any<CancellationToken>()).Returns(mockResponse);
            var service = new RequestService(_rpc, _logger);

            //Act
            var result = await service.SimpleMessageRequest(request, CancellationToken.None);

            //Assert
            Assert.Equal("test", result.ResponseText);
            Assert.Equal(new TimeSpan(1000), result.Timespam);
        }

    }
}
