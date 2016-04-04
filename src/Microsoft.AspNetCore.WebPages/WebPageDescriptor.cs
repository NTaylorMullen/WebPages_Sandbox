using Microsoft.Extensions.FileProviders;

namespace Microsoft.AspNetCore.WebPages
{
    public class WebPageDescriptor
    {
        public IFileInfo WebPageFile { get; set; }
    }
}
