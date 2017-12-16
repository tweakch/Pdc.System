namespace Pdc.System
{
    /// <summary>
    /// Represents a process running within a Transmitter.
    /// </summary>
    // #refactor Extract to Pdc.Data.Process namespace
    public interface ITransmitterProcess
    {
        void Run();

        int Errors { get; }
    }
}