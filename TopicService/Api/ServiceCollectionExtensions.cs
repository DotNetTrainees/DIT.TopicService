using Microsoft.Extensions.DependencyInjection;

namespace TopicService.Api
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers();
        }
    }
}
