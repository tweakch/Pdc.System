using System.Net.Http;
using Pdc.Net.Http.Configuration;
using Pdc.System.Validation;

namespace Pdc.Net.Http.Validation
{
    public interface IHttpContentValidator
    {
        IValidationResult Validate(HttpContent content, IHttpClientConfiguration configuration);
    }
}