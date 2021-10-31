using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TopicService.Tests.Integration
{
    public class ReplyEndpointsTest : IClassFixture<TestServerFixture>
    {
        private readonly TestServerFixture _fixture;

        public ReplyEndpointsTest(TestServerFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [InlineData("b35dcb32-e60f-4fa3-935e-800cf03acc77")]
        public async Task GetAllRepliesAsync(Guid topicId)
        {
            var apiResponse = await _fixture.Client.GetAsync($"v1/reply/get-by-topic/{topicId}");
            Assert.Equal(StatusCodes.Status200OK, (int)apiResponse.StatusCode);
        }
    }
}
