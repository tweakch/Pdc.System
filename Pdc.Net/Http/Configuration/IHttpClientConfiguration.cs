using System.Net.Http;
using System.Net.Http.Headers;

namespace Pdc.Net
{
    public interface IHttpClientConfiguration
    {
        HttpContentHeaders ValidHeaders { get; set; }
    }
}