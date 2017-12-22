using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Pdc.System.Component
{
    //#refactor Merge with IHttpClientConfiguration from Pdc.Net
    public class JsonClientSettings : IHttpClientSettings
    {
        public JsonClientSettings()
        {
            AcceptHeaders = new List<MediaTypeWithQualityHeaderValue>
            {
                new MediaTypeWithQualityHeaderValue("application/json")
            };
        }

        public List<MediaTypeWithQualityHeaderValue> AcceptHeaders { get; set; }
    }
}