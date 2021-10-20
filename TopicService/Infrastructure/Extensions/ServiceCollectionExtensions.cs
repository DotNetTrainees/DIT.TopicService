using Microsoft.Extensions.DependencyInjection;

namespace TopicService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
    }
}
