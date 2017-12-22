using Pdc.Net.Http.Validation;
using Pdc.System.Validation;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Pdc.Net.Http.Configuration
{
    public class HttpJsonClientConfiguration : IHttpClientConfiguration
    {
        public HttpContentHeaders ValidHeaders { get; set; }
        public IHttpContentValidator ContentValidator { get; }

        public HttpJsonClientConfiguration()
        {
            ContentValidator = new HttpJsonContentValidator();
        }

        private class HttpJsonContentValidator : IHttpContentValidator
        {
            public IValidationResult Validate(HttpContent content, IHttpClientConfiguration configuration)
            {
                return null;
            }
        }
    }
}