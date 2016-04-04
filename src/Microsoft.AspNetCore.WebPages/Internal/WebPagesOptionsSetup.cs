using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Microsoft.AspNetCore.WebPages.Internal
{
    public class WebPagesOptionsSetup : IConfigureOptions<WebPagesOptions>
    {
        public void Configure(WebPagesOptions options)
        {
            options.WebPageLocation = "/Views";
        }
    }
}
