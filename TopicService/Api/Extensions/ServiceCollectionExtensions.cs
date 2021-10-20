using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TopicService.Api.Filters;
using TopicService.Data.Entities;

namespace TopicService.Api.Extensions
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
                    Title = "topic_service_v1",
                    Version = "v1",
                    Description = "dev"
                });
            });
        }

        public static void ConfigureFilters(this IServiceCollection services)
        {
            services.AddScoped<ValidateModelFilter>();
            services.AddScoped<ValidateEntityExistsFilter<Topic>>();
            services.AddScoped<ValidateEntityExistsFilter<Reply>>();
        }
    }
}
