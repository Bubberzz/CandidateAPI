using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace CandidateAPI.Tests.Middleware.Unit_Tests
{
    public class PostCandidateShouldReturnOK
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public PostCandidateShouldReturnOK()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task ReturnResponseOK()
        {
            // Act
            const string jsonObject =
                "{\r\n  \"id\": \"ae588a6b-4540-5714-bfe2-a5c2a65f547abcdef1221\",\r\n  \"name\": \"Jimmy Coder\",\r\n  \"skills\": [ \"adobe\", \"photoshop\", \"csharp\", \"javascript\" ]\r\n}";
            const string url = "https://localhost:44387/api/candidates";
            var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            var response = _client.PostAsync(url, content).Result;

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
