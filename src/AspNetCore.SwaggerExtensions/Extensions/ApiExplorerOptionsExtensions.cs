using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace AspNetCore.SwaggerExtensions.Extensions
{
    /// <summary>
    /// Adds additional extensions to ApiExplorerOptions
    /// </summary>
    public static class ApiExplorerOptionsExtensions
    {
        /// <summary>
        /// Sets default options
        /// </summary>
        /// <param name="options">Options</param>
        /// <returns>Extended options</returns>
        public static ApiExplorerOptions SetDefaults(this ApiExplorerOptions options)
        {
            options.DefaultApiVersion = ApiVersion.Parse("1.0");
            options.SubstituteApiVersionInUrl = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.GroupNameFormat = "'v'VVV";

            return options;
        }
    }
}
