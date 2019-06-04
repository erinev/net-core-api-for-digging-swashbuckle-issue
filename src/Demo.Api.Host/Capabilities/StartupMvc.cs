using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Demo.Api.Host.Capabilities
{
    public static class StartupMvc
    {
        public static IMvcCoreBuilder ConfigureMvc(this IServiceCollection services)
        {
            return services
                .AddMvcCore(options =>
                {
                    options.ReturnHttpNotAcceptable = true;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .ConfigureJson();
        }

        private static IMvcCoreBuilder ConfigureJson(this IMvcCoreBuilder builder)
        {
            builder.AddFormatterMappings();

            builder.AddJsonFormatters(f =>
                {
                    f.Formatting = Formatting.Indented;
                    f.NullValueHandling = NullValueHandling.Ignore;
                    f.MissingMemberHandling = MissingMemberHandling.Ignore;
                });

            builder.AddJsonOptions(options =>
                {
                    options.SerializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;

                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                    JsonConvert.DefaultSettings = () => new JsonSerializerSettings
                    {
                        Formatting = Formatting.Indented,
                        Converters = new List<JsonConverter> { new StringEnumConverter() },
                        DateParseHandling = DateParseHandling.DateTimeOffset,
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    };
                });

            return builder;
        }
    }
}
