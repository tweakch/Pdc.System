using System.Linq;
using System.Net.Http;
using Pdc.Net.Http.Configuration;
using Pdc.System.Validation;

namespace Pdc.Net.Http.Validation
{
    public class HttpContentValidator : IHttpContentValidator
    {
        private abstract class AValidationResult : IValidationResult
        {
            public IValidationErrorCollection ValidationErrors { get; protected set; }
            public bool HasErrors { get; protected set; }
        }

        private class ValidationOk : AValidationResult
        {
            public ValidationOk()
            {
                HasErrors = false;
                ValidationErrors = null;
            }
        }

        private class ValidationFailed : AValidationResult
        {
            public ValidationFailed(IValidationErrorCollection errors)
            {
                HasErrors = true;
                ValidationErrors = errors;
            }
        }


        public IValidationResult Validate(HttpContent content, IHttpClientConfiguration configuration)
        {
            IValidationErrorCollection errors = new ValidationErrorCollection();

            var mediaType = configuration.ValidHeaders.ContentType.MediaType;

            if (!content.Headers.Contains(mediaType))
            {
                //#refactor message into resource file
                var validationError = new InvalidContentTypeError($"Configured media type {mediaType} is missing in headers.");
                errors.Add(validationError);
            }

            if (errors.Any()) { return new ValidationFailed(errors);}
            return new ValidationOk();
        }

        

        public class InvalidContentTypeError : AValidationError
        {
            public InvalidContentTypeError(string s) : base(s)
            {
            }
        }
    }
}