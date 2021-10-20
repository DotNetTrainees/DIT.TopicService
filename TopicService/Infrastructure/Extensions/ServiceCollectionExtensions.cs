using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TopicService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(opts =>
                opts.UseSqlServer(
                    configuration.GetConnectionString("DatabaseConnection"), 
                    b => b.MigrationsAssembly("TopicService.Infrastructure")));
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
    }
}
