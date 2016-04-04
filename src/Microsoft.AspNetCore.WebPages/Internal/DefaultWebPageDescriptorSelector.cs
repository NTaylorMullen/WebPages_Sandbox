using Microsoft.AspNetCore.Routing;

namespace Microsoft.AspNetCore.WebPages.Internal
{
    public class DefaultWebPageDescriptorSelector : IWebPageDescriptorSelector
    {
        private readonly IWebPageDescriptorProvider _descriptorProvider;

        public DefaultWebPageDescriptorSelector(IWebPageDescriptorProvider descriptorProvider)
        {
            _descriptorProvider = descriptorProvider;
        }

        public WebPageDescriptor Select(RouteContext routeContext)
        {
            return _descriptorProvider.Descriptors[0];
        }
    }
}
