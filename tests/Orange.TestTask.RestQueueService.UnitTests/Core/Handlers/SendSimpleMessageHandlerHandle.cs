using Moq;
using Orange.TestTask.RestQueueService.Core.Commands;
using Orange.TestTask.RestQueueService.Core.Handlers;
using Orange.TestTask.RestQueueService.Core.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Orange.TestTask.RestQueueService.UnitTests.Core.Handlers
{
    public class SendSimpleMessageHandlerHandle
    {
        private readonly SendSimpleMessageHandler _handler;
        private readonly Mock<IQueueRequestService> _queueMock;

        public SendSimpleMessageHandlerHandle()
        {
            _queueMock = new Mock<IQueueRequestService>();
            _handler = new SendSimpleMessageHandler(_queueMock.Object);
        }

        [Fact]
        public async Task SendSimpleMessageGivenEventInstance()
        {
            await _handler.Handle(new SimpleMessageParam("text"), CancellationToken.None);

            _queueMock.Verify(sender => sender.SimpleMessageRequest(It.IsAny<SimpleMessageParam>(), It.IsAny<CancellationToken>()));
        }
    }
}
