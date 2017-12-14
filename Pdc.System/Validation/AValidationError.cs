using System;

namespace Pdc.System.Validation
{
    public abstract class AValidationError : IValidationError
    {
        protected AValidationError(string message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            Message = message;
        }

        public string Message { get; }
    }
}