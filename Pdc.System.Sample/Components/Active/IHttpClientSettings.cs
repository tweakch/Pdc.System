using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Pdc.System.Sample.Components.Active
{
    //#refactor Merge with IHttpClientConfiguration from Pdc.Net
    public interface IHttpClientSettings
    {
        List<MediaTypeWithQualityHeaderValue> AcceptHeaders { get; set; }
    }
}