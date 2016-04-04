using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Microsoft.AspNetCore.WebPages
{
    public static class WebPagesApplicaitonBuilderExtensions
    {
        public static IApplicationBuilder UseWebPages(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            var routeBuilder = new RouteBuilder(app)
            {
                DefaultHandler = new WebPagesRouteHandler()
            };

            routeBuilder.MapRoute(
                name: "default",
                template: "{view=Index}");

            return app.UseRouter(routeBuilder.Build());
        }
    }
}
