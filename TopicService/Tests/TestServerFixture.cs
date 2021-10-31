using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net.Http;
using TopicService.Api;
using TopicService.Infrastructure;

namespace TopicService.Tests
{
    public class TestServerFixture
    {
        public HttpClient Client { get; }
        public RepositoryManager Repository { get; }

        public TestServerFixture()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var webBuilder = new WebHostBuilder()
                .UseConfiguration(builder.Build())
                .UseStartup<Startup>();

            var server = new TestServer(webBuilder);
            Client = server
                .CreateClient();

            Repository = server.Host.Services
                .GetService(typeof(RepositoryManager)) as RepositoryManager;
        }

        public void Dispose()
        {
            Client.Dispose();
        }
    }
}
