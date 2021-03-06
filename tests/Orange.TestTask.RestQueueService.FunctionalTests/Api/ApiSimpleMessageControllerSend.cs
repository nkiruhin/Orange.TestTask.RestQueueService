using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Orange.TestTask.RestQueueService.Web;
using Newtonsoft.Json;
using Orange.TestTask.RestQueueService.Contracts.Models;
using Orange.TestTask.RestQueueService.Web.ApiModels;
using Xunit;

namespace Orange.TestTask.RestQueueService.FunctionalTests.Api
{
    public class ApiSimpleMessageControllerSend : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ApiSimpleMessageControllerSend(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsTextAndTime()
        {
            var simpleMessage = new SimpleMessageDto
            {
                Text = "text"
            };
            var stringContent = new StringContent(JsonConvert.SerializeObject(simpleMessage), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/SimpleMessage", stringContent );
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SimpleMessageResponse>(stringResponse);
            Assert.Equal(result.ResponseText, simpleMessage.Text);
            Assert.True(result.Timespam.Ticks > 0);
        }
    }
}
