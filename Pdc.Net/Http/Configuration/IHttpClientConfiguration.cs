using Pdc.Net.Http.Validation;
using System.Net.Http.Headers;

namespace Pdc.Net.Http.Configuration
{
    public interface IHttpClientConfiguration
    {
        HttpContentHeaders ValidHeaders { get; set; }
        IHttpContentValidator ContentValidator { get; }
    }
}