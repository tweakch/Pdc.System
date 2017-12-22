using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Pdc.System.Component
{
    //#refactor Merge with IHttpClientConfiguration from Pdc.Net
    public interface IHttpClientSettings
    {
        List<MediaTypeWithQualityHeaderValue> AcceptHeaders { get; set; }
    }
}