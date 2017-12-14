using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;

namespace Pdc.Net
{
    public abstract class HttpClientConfiguration : IHttpClientConfiguration
    {
        public static IHttpClientConfiguration DefaultConfiguration => new DefaultHttpClientConfiguration();
        public HttpContentHeaders ValidHeaders { get; set; }
    }

    public class DefaultHttpClientConfiguration : HttpClientConfiguration
    {
        public string ContentType => "application/json";
    }
}