namespace Pdc.System
{
    /// <summary>
    ///     Defines a mechanism to send data to hosts.
    /// </summary>
    public interface IClient
    {
        /// <summary>
        /// Sends data to the host of this client.
        /// </summary>
        /// <param name="data">The data that will be sent.</param>
        void Send(object data);
    }
}