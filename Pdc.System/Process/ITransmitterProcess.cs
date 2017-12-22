namespace Pdc.System.Process
{
    /// <summary>
    ///     Represents a process running within a Transmitter.
    /// </summary>
    public interface ITransmitterProcess
    {
        /// <summary>
        ///
        /// </summary>
        int Errors { get; }

        /// <summary>
        ///
        /// </summary>
        void Run();
    }
}