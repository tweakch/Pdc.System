using System;

namespace Pdc.System.Validation
{
    /// <summary>
    ///
    /// </summary>
    public abstract class AValidationError : IValidationError
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <exception cref="ArgumentNullException"></exception>
        protected AValidationError(string message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            Message = message;
        }

        /// <summary>
        ///
        /// </summary>
        public string Message { get; }
    }
}