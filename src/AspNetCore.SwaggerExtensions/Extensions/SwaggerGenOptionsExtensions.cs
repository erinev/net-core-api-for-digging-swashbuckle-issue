using System.IO;
using System.Reflection;
using AspNetCore.SwaggerExtensions.Filters;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AspNetCore.SwaggerExtensions.Extensions
{
    /// <summary>
    /// Adds additional extensions to SwaggerGenOptions
    /// </summary>
    public static class SwaggerGenOptionsExtensions
    {
        /// <summary>
        /// Sets default options
        /// </summary>
        /// <param name="options">Options instance</param>
        /// <returns>Extended options</returns>
        public static SwaggerGenOptions SetDefaults(this SwaggerGenOptions options)
        {
            options.DescribeAllEnumsAsStrings();
            options.DescribeStringEnumsInCamelCase();
            options.IgnoreObsoleteActions();
            options.IgnoreObsoleteProperties();

            return options;
        }

        /// <summary>
        /// Registers default filters
        /// </summary>
        /// <param name="options">Options instance</param>
        /// <returns>Extended options</returns>
        public static SwaggerGenOptions RegisterDefaultFilters(this SwaggerGenOptions options)
        {
            options.OperationFilter<DefaultValuesOperationFilter>();
            options.OperationFilter<AddResponseHeadersFilter>();

            return options;
        }

        /// <summary>
        /// Registers default Swagger documents
        /// </summary>
        /// <param name="options">Options instance</param>
        /// <param name="services">Services</param>
        /// <param name="info">Information</param>
        /// <returns>Extended options</returns>
        public static SwaggerGenOptions RegisterDefaultDocs(this SwaggerGenOptions options, IServiceCollection services, Info info = null)
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

        /// <summary>
        /// Automatically includes XML comments
        /// </summary>
        /// <param name="options">Options instance</param>
        /// <returns>Extended options</returns>
        public static SwaggerGenOptions IncludeXmlComments(this SwaggerGenOptions options)
        {
            var assemblyPath = Assembly.GetCallingAssembly().Location;
            var assemblyDir = Path.GetDirectoryName(assemblyPath);
            var files = Directory.GetFiles(assemblyDir, "*.xml", SearchOption.TopDirectoryOnly);

            foreach (var xmlPath in files)
            {
                if (File.Exists(xmlPath))
                    options.IncludeXmlComments(xmlPath);
            }

            return options;
        }
    }
}
