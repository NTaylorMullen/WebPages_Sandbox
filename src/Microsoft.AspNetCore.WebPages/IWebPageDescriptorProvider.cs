using System.Collections.Generic;

namespace Microsoft.AspNetCore.WebPages
{
    public interface IWebPageDescriptorProvider
    {
        IReadOnlyList<WebPageDescriptor> Descriptors { get; }
    }
}
