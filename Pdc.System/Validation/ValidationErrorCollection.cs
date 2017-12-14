using System.Collections;
using System.Collections.Generic;

namespace Pdc.System.Validation
{
    /// <summary>
    ///     Simply wraps a <see cref="List{T}" /> where T is of type <see cref="IValidationError" />
    /// </summary>
    public class ValidationErrorCollection : IValidationErrorCollection
    {
        private readonly List<IValidationError> _errors;

        public ValidationErrorCollection()
        {
            _errors = new List<IValidationError>();
        }

        public IEnumerator<IValidationError> GetEnumerator()
        {
            return _errors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(IValidationError item)
        {
            _errors.Add(item);
        }

        public void Clear()
        {
            _errors.Clear();
        }

        public bool Contains(IValidationError item)
        {
            return _errors.Contains(item);
        }

        public void CopyTo(IValidationError[] array, int arrayIndex)
        {
            _errors.CopyTo(array, arrayIndex);
        }

        public bool Remove(IValidationError item)
        {
            return _errors.Remove(item);
        }

        public int Count => _errors.Count;

        public bool IsReadOnly => false;
    }
}