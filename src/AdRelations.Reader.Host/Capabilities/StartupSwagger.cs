using AspNetCore.SwaggerExtensions.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace AdRelations.Reader.Host.Capabilities
{
    public static class StartupSwagger
    {
        public static IMvcCoreBuilder ConfigureSwaggerDependencies(this IMvcCoreBuilder builder)
        {
            return builder.AddApiExplorer();
        }

        public static IServiceCollection ConfigureSwagger(this IServiceCollection services, IConfigurationRoot configuration)
        {
            return services.AddSwagger(options =>
            {
                options.SetDefaults();
                options.IncludeXmlComments();
                options.RegisterDefaultFilters();

                options.RegisterDefaultDocs(services, new Info
                {
                    Title = configuration.GetValue<string>("Swagger:Title"),
                    Description = configuration.GetValue<string>("Swagger:Description"),
                });
            });
        }

        public static IApplicationBuilder UseSwaggerUi(this IApplicationBuilder app, IApiVersionDescriptionProvider provider, IConfigurationRoot configuration)
        {
            return app.UseSwaggerWithUi(options =>
            {
                options.SetDefaults();
                options.RegisterDefaultEndpoints(provider);
            });
        }
    }
}
