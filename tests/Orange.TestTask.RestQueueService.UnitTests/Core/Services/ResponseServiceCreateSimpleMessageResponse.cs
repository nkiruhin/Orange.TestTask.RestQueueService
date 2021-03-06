using Microsoft.Extensions.Logging;
using NSubstitute;
using Orange.TestTask.RestQueueService.Core.Commands;
using Orange.TestTask.RestQueueService.Infrastructure.Queue.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Orange.TestTask.RestQueueService.UnitTests.Core.Services
{
    public class ResponseServiceCreateSimpleMessageResponse
    {
        private readonly ILogger<ResponseService> _logger;

        public ResponseServiceCreateSimpleMessageResponse()
        {
            _logger = Substitute.For<ILogger<ResponseService>>();
        }

        [Fact]
        public async Task ReturnsSimpleMessageResponse()
        {
            //Arrange
            var service = new ResponseService(_logger);

            //Act
            var result = await service.CreateSimpleMessageResponse(new SimpleMessageParam("test") { CreateTimestamp = DateTimeOffset.Now });

            //Assert
            Assert.Equal("Responding to test", result.ResponseText);
            Assert.True(result.Timespam.Ticks > 0);
        }
    }
}
