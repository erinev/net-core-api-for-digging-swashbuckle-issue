using System;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AspNetCore.SwaggerExtensions.Extensions
{
    /// <summary>
    /// Adds additional extensions to IServiceCollection
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the Swagger service with API versioning
        /// </summary>
        /// <param name="services">Services container</param>
        /// <param name="apiVersioningSetupAction">API versioning configuration</param>
        /// <param name="swaggerSetupAction">Swagger configuration</param>
        /// <param name="apiExplorerSetupAction">API explorer configuration</param>
        public static IServiceCollection AddSwagger(this IServiceCollection services, Action<SwaggerGenOptions> swaggerSetupAction = null,
            Action<ApiVersioningOptions> apiVersioningSetupAction = null, Action<ApiExplorerOptions> apiExplorerSetupAction = null)
        {
            services.AddMvcCore().AddVersionedApiExplorer(apiExplorerSetupAction ?? (options => { options.SetDefaults(); }));
            services.AddApiVersioning(apiVersioningSetupAction ?? (options => {}));
            services.AddSwaggerGen(swaggerSetupAction ?? (options => { options.SetDefaults(); }));

            return services;
        }
    }
}
