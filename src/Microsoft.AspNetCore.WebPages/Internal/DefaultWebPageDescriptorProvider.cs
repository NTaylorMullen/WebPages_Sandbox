using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Microsoft.AspNetCore.WebPages.Internal
{
    public class DefaultWebPageDescriptorProvider : IWebPageDescriptorProvider
    {
        private const string ViewExtension = ".cshtml";
        private readonly IServiceProvider _serviceProvider;
        private IReadOnlyList<WebPageDescriptor> _descriptors;

        public DefaultWebPageDescriptorProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IReadOnlyList<WebPageDescriptor> Descriptors
        {
            get
            {
                if (_descriptors == null)
                {
                    _descriptors = DiscoverWebPageDescriptors();
                }

                return _descriptors;
            }
        }

        private IReadOnlyList<WebPageDescriptor> DiscoverWebPageDescriptors()
        {
            var loggerFactory = _serviceProvider.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger<DefaultWebPageDescriptorProvider>();
            var webPageOptions = _serviceProvider.GetRequiredService<IOptions<WebPagesOptions>>().Value;
            var hostingEnv = _serviceProvider.GetRequiredService<IHostingEnvironment>();
            var fileProvider = hostingEnv.ContentRootFileProvider;
            var webPageDirectory = fileProvider.GetDirectoryContents(webPageOptions.WebPageLocation);

            foreach (var item in webPageDirectory)
            {
                logger.LogDebug("Found item: " + item.PhysicalPath);
            }

            return webPageDirectory.Select(fileInfo => new WebPageDescriptor { WebPageFile = fileInfo }).ToList();
        }
    }
}
