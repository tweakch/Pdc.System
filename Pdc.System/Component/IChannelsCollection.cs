using Pdc.System.Component.Connector;
using System;
using System.Collections.Generic;

namespace Pdc.System.Component
{
    /// <summary>
    ///
    /// </summary>
    public interface IChannelsCollection : ICollection<IComponentChannel>
    {
        /// <summary>
        ///     Returns true if the channelName exists, otherwise false
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns></returns>
        bool Contains(string channelName);

        /// <summary>
        ///
        /// </summary>
        /// <param name="channelName"></param>
        IComponentChannel this[string channelName] { get; }
    }

    /// <summary>
    ///
    /// </summary>
    public interface IComponentChannel
        : IEquatable<IComponentChannel>
    {
        /// <summary>
        /// The name of the channel
        /// </summary>
        string Name { get; set; }

        /// <summary>
        ///     The environment of the channel
        /// </summary>
        /// <returns></returns>
        IChannelEnvironment Environment { get; }
    }
}