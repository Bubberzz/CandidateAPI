using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace CandidateAPI.Tests.Controllers.Integration_Tests
{
    public class GetCandidateShouldReturnOK
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public GetCandidateShouldReturnOK()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();

            const string jsonObject =
                "{\r\n  \"id\": \"ae588a6b-4540-5714-bfe2-a5c2a65f547abcdef1221\",\r\n  \"name\": \"Jimmy Coder\",\r\n  \"skills\": [ \"adobe\", \"photoshop\", \"csharp\", \"javascript\" ]\r\n}";
            const string url = "https://localhost:44374/api/candidates";
            var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            _client.PostAsync(url, content);

        }

        [Fact]
        public async Task ReturnResponseOK()
        {
            // Act
            var response = await _client.GetAsync("https://localhost:44374/api/candidates/search?skills=javascript");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            const string expectedResponse = "[{\"id\":\"ae588a6b-4540-5714-bfe2-a5c2a65f547abcdef1221\",\"name\":\"Jimmy Coder\",\"skills\":[\"adobe\",\"photoshop\",\"csharp\",\"javascript\"]}]";

            // Assert
            Assert.Equal(expectedResponse, responseString);
        }
    }
}
