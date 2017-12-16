namespace Pdc.System.Process
{
    /// <summary>
    ///     Represents a process running within a Transmitter.
    /// </summary>
    public interface ITransmitterProcess
    {
        int Errors { get; }
        void Run();
    }
}