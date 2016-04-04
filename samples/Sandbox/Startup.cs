using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.WebPages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Sandbox
{
    public class Startup
    {
        private readonly IHostingEnvironment _hostingEnv;

        public Startup(IHostingEnvironment hostingEnv)
        {
            _hostingEnv = hostingEnv;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddWebPages();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole((name, logLevel) => name.StartsWith("Microsoft.AspNetCore.WebPages"));

            app.UseIISPlatformHandler();
            app.UseWebPages();
        }
    }
}
