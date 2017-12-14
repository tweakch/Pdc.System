using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
