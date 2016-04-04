using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;

namespace Microsoft.AspNetCore.WebPages
{
    public interface IWebPageDescriptorSelector
    {
        WebPageDescriptor Select(RouteContext context);
    }
}
