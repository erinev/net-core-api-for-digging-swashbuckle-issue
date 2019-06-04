using Demo.Api.Host.Capabilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Api.Host
{
    /// <summary>
    /// Application startup configuration class.
    /// </summary>
    /// <remarks>Invoke extensions methods defined in Capabilities extension classes.</remarks>
    public class Startup
    {
        private IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            Configuration = hostingEnvironment
                .ConfigureConfig();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">Services collection.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .ConfigureSwagger(Configuration)
                .ConfigureMvc();
        }

        /// <summary>
        /// This method gets called by the runtime.
        /// Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Application builder.</param>
        /// <param name="env">Hosting environment.</param>
        /// <param name="provider">Api version description provider.</param>
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            IApiVersionDescriptionProvider provider)
        {
            app
                .UseMvc()
                .UseSwaggerUi(provider, Configuration);
        }
    }
}
