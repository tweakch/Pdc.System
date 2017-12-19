namespace Pdc.System.Validation
{
    /// <summary>
    /// 
    /// </summary>
    public interface IValidationResult
    {
        /// <summary>
        /// 
        /// </summary>
        IValidationErrorCollection ValidationErrors { get; }
        /// <summary>
        /// 
        /// </summary>
        bool HasErrors { get; }
    }
}