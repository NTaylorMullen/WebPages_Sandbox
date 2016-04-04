using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNetCore.WebPages
{
    public class WebPagesRouteHandler : IRouter
    {
        private readonly RequestDelegate _onInvokeWebPageAsyncCache;

        private IWebPageDescriptorSelector _descriptorSelector;
        private ILogger _logger;
        private bool _servicesRetrieved;

        public WebPagesRouteHandler()
        {
            _onInvokeWebPageAsyncCache = InvokeWebPageAsync;
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return null;
        }

        public Task RouteAsync(RouteContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            EnsureServices(context.HttpContext);
            var httpContext = context.HttpContext;
            if (!string.Equals("GET", httpContext.Request.Method, StringComparison.OrdinalIgnoreCase))
            {
                return Task.CompletedTask;
            }

            var webPageDescriptor = _descriptorSelector.Select(context);
            if (webPageDescriptor != null)
            {
                _logger.LogInformation("Descriptor found.");
                context.Handler = _onInvokeWebPageAsyncCache;
            }

            return Task.CompletedTask;
        }

        private Task InvokeWebPageAsync(HttpContext context)
        {
            return Task.CompletedTask;
        }

        private void EnsureServices(HttpContext context)
        {
            if (_servicesRetrieved)
            {
                return;
            }

            var requestServices = context.RequestServices;
            var loggerFactory = requestServices.GetRequiredService<ILoggerFactory>();
            _logger = loggerFactory.CreateLogger<WebPagesRouteHandler>();
            _descriptorSelector = requestServices.GetRequiredService<IWebPageDescriptorSelector>();

            _servicesRetrieved = true;
        }
    }
}
