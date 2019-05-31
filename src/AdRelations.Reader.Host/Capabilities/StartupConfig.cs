using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace AdRelations.Reader.Host.Capabilities
{
    public static class StartupConfig
    {
        public static IConfigurationRoot ConfigureConfig(this IHostingEnvironment environment)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();

            string configurationFile = "appsettings.json";

            return builder
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile(configurationFile)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
