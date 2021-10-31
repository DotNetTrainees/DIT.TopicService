using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using TopicService.Data.Entities;
using Xunit;

namespace TopicService.Tests.Integration
{
    public class TopicEndpointsTest : IClassFixture<TestServerFixture>
    {
        private readonly TestServerFixture _fixture;

        public TopicEndpointsTest(TestServerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetAllTopicsAsync()
        {
            var apiResponse = await _fixture.Client.GetAsync("v1/topic/get-all");
            Assert.Equal(StatusCodes.Status200OK, (int)apiResponse.StatusCode);
        }

    }
}
