using MediatR;
using Orange.TestTask.RestQueueService.Contracts.Models;
using System;

namespace Orange.TestTask.RestQueueService.Core.Commands
{
    public class SimpleMessageParam: IRequest<SimpleMessageResponse>
    {
        public SimpleMessageParam(string text)
        {
            Text = text;
        }

        public DateTimeOffset CreateTimestamp { get; set; }
        public string Text { get; set; }
    }
}
