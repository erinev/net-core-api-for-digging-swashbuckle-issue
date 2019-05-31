using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace AspNetCore.SwaggerExtensions.Extensions
{
    /// <summary>
    /// Adds additional extensions to SwaggerUIOptions
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static class SwaggerUIOptionsExtensions
    {
        /// <summary>
        /// Sets default options
        /// </summary>
        /// <param name="options">Options instance</param>
        /// <returns>Extended options</returns>
        public static SwaggerUIOptions SetDefaults(this SwaggerUIOptions options)
        {
            options.DefaultModelRendering(ModelRendering.Example);
            options.DefaultModelExpandDepth(0);
            options.DefaultModelsExpandDepth(0);
            options.DisplayRequestDuration();
            options.DocExpansion(DocExpansion.List);
            options.EnableFilter();

            return options;
        }

        /// <summary>
        /// Automatically register all endpoints
        /// </summary>
        /// <param name="options">Options instance</param>
        /// <param name="provider">API version provider</param>
        /// <returns>Extended options</returns>
        public static SwaggerUIOptions RegisterDefaultEndpoints(this SwaggerUIOptions options, IApiVersionDescriptionProvider provider)
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                if (string.IsNullOrWhiteSpace(description.GroupName))
                    continue;

                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName);
            }

            return options;
        }
    }
}
