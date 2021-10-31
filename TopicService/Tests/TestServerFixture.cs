using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net.Http;
using TopicService.Api;

namespace TopicService.Tests
{
    public class TestServerFixture
    {
        public HttpClient Client { get; }

        public TestServerFixture()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var webBuilder = new WebHostBuilder()
                .UseConfiguration(builder.Build())
                .UseStartup<Startup>();

            Client = new TestServer(webBuilder)
                .CreateClient();
        }

        public void Dispose()
        {
            Client.Dispose();
        }
    }
}
