namespace Pdc.System.Component.Connector
{
    /// <summary>
    ///     Provides the interface for the active component.
    /// </summary>
    public interface IChannelsConnector : IConnector
    {
        /// <summary>
        /// Returns True if a channel with the given name exists, otherwise False
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns></returns>
        bool ContainsChannel(string channelName);

        /// <summary>
        /// The component the selector has been bound to
        /// </summary>
        ActiveComponentBase Component { get; }
    }
}