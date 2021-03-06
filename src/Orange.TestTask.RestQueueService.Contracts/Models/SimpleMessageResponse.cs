using System;

namespace Orange.TestTask.RestQueueService.Contracts.Models
{
    // Note: doesn't expose events or behavior
    public class SimpleMessageResponse
    {
        /// <summary>
        /// Сообщение ответа
        /// </summary>
        public string ResponseText { get; set; }
        /// <summary>
        /// Время затраченное на перепесылку сообщения
        /// </summary>
        public TimeSpan Timespam { get; set; }
    }
}
