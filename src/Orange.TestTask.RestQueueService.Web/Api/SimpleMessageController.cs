using MediatR;
using Microsoft.AspNetCore.Mvc;
using Orange.TestTask.RestQueueService.Core.Commands;
using Orange.TestTask.RestQueueService.Web.ApiModels;
using System.Threading;
using System.Threading.Tasks;

namespace Orange.TestTask.RestQueueService.Web.Api
{
    public class SimpleMessageController : BaseApiController
    {
        private readonly IMediator _mediator;
        public SimpleMessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/SimpleMessage
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SimpleMessageDto simpleMessage, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(new SimpleMessageParam(simpleMessage.Text), cancellationToken);
            return Ok(response);
        }
    }
}
