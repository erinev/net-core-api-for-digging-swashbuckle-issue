using System;
using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace AspNetCore.SwaggerExtensions.Extensions
{
    /// <summary>
    /// Adds additional extensions to IApplicationBuilder
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Registers the Swagger JSON and UI 
        /// </summary>
        /// <param name="app">Application pipeline</param>
        /// <param name="uiSetupAction">Swagger UI middleware configuration</param>
        /// <param name="swaggerSetupAction">Swagger middleware configuration</param>
        public static IApplicationBuilder UseSwaggerWithUi(this IApplicationBuilder app, Action<SwaggerUIOptions> uiSetupAction = null, 
            Action<SwaggerOptions> swaggerSetupAction = null)
        {
            app.UseSwagger(swaggerSetupAction ?? (options => { }));
            app.UseSwaggerUI(uiSetupAction ?? (options => { }));

            return app;
        }
    }
}
