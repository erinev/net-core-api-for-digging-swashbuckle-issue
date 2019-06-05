using Demo.Api.Host.Capabilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
        }
    }
}