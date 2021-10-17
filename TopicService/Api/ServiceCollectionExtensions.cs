using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace TopicService.Api
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureControllers(this IServiceCollection services) =>
            services.AddControllers();

        public static void ConfigureVersioning(this IServiceCollection services) =>
            services.AddApiVersioning();

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "topic_servicei_v1",
                    Version = "v1",
                    Description = "dev"
                });
            });
        }
    }
}
