using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Pdc.System.Sample.Components.Active
{
    //#refactor Merge with IHttpClientConfiguration from Pdc.Net
    public class JsonClientHeaderValues : IHttpClientSettings
    {
        public JsonClientHeaderValues()
        {
            AcceptHeaders = new List<MediaTypeWithQualityHeaderValue>
            {
                new MediaTypeWithQualityHeaderValue("application/json")
            };
        }

        public List<MediaTypeWithQualityHeaderValue> AcceptHeaders { get; set; }
    }
}