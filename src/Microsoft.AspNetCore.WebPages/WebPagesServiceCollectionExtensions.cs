using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebPages.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Microsoft.AspNetCore.WebPages
{
    public static class WebPagesServiceCollectionExtensions
    {
        public static IServiceCollection AddWebPages(this IServiceCollection services)
        {
            services.AddRouting();
            services.TryAddEnumerable(
                ServiceDescriptor.Transient<IConfigureOptions<WebPagesOptions>, WebPagesOptionsSetup>());
            services.AddSingleton<IWebPageDescriptorProvider, DefaultWebPageDescriptorProvider>();
            services.AddSingleton<IWebPageDescriptorSelector, DefaultWebPageDescriptorSelector>();

            return services;
        }
    }
}
