using Pdc.Net.Http.Configuration;
using Pdc.System.Validation;
using System.Net.Http;

namespace Pdc.Net.Http.Validation
{
    public interface IHttpContentValidator
    {
        IValidationResult Validate(HttpContent content, IHttpClientConfiguration configuration);
    }
}