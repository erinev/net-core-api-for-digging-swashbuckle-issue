using Demo.Api.Host.Capabilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Api.Host
{
    public class Startup
    {
        private IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            Configuration = hostingEnvironment
                .ConfigureConfig();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .ConfigureSwagger(Configuration)
                .ConfigureMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app
                .UseMvc()
                .UseSwaggerUi(provider);
        }
    }
}
