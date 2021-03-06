using System.ComponentModel.DataAnnotations;

namespace Orange.TestTask.RestQueueService.Web.ApiModels
{
    public class SimpleMessageDto
    {
        /// <summary>
        /// Текст сообщения
        /// </summary>
        [Required]
        public string Text { get; set; }
    }
}