namespace Pdc.System.Validation
{
    public interface IValidationResult
    {
        IValidationErrorCollection ValidationErrors { get; }
        bool HasErrors { get; }
    }
}