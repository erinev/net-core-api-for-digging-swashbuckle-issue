using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Demo.Api.Host.Capabilities
{
    public static class StartupSwagger
    {
        public static IMvcCoreBuilder ConfigureSwaggerDependencies(this IMvcCoreBuilder builder)
        {
            return builder.AddApiExplorer();
        }

        public static IServiceCollection ConfigureSwagger(this IServiceCollection services,
            IConfigurationRoot configuration)
        {
            return services.AddSwagger(options =>
            {
                options.RegisterDefaultDocs(services, new Info
                {
                    Title = configuration.GetValue<string>("Swagger:Title"),
                    Description = configuration.GetValue<string>("Swagger:Description"),
                });
            });
        }

        public static IApplicationBuilder UseSwaggerUi(this IApplicationBuilder app,
            IApiVersionDescriptionProvider provider)
        {
            return app
                .UseSwagger()
                .UseSwaggerUI((options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        if (string.IsNullOrWhiteSpace(description.GroupName))
                            continue;

                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName);
                    }
                }));
        }

        #region Extensions

        private static IServiceCollection AddSwagger(this IServiceCollection services, Action<SwaggerGenOptions> swaggerSetupAction = null)
        {
            services.AddMvcCore().AddVersionedApiExplorer((options =>
            {
                options.DefaultApiVersion = ApiVersion.Parse("1.0");
                options.SubstituteApiVersionInUrl = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.GroupNameFormat = "'v'VVV";
            }));
            services.AddApiVersioning();
            services.AddSwaggerGen(swaggerSetupAction);

            return services;
        }

        private static SwaggerGenOptions RegisterDefaultDocs(this SwaggerGenOptions options,
            IServiceCollection services, Info info = null)
        {
            var provider = services.BuildServiceProvider().GetService<IApiVersionDescriptionProvider>();

            if (provider == null)
                return options;

            foreach (var description in provider.ApiVersionDescriptions)
            {
                if (string.IsNullOrEmpty(description.GroupName))
                    continue;

                options.SwaggerDoc(description.GroupName, new Info
                {
                    Version = description.GroupName,
                    Title = info?.Title,
                    Description = info?.Description,
                    Contact = info?.Contact,
                    License = info?.License,
                    TermsOfService = info?.TermsOfService
                });
            }

            return options;
        }

        #endregion
    }
}
