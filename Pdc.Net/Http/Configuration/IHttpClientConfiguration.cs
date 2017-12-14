using System.Net.Http.Headers;
using Pdc.Net.Http.Validation;

namespace Pdc.Net.Http.Configuration
{
    public interface IHttpClientConfiguration
    {
        HttpContentHeaders ValidHeaders { get; set; }
        IHttpContentValidator ContentValidator { get; }
    }
}