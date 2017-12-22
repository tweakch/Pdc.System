using Pdc.System.Component.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pdc.System.Component
{
    /// <summary>
    ///     Abstract base class for all Active Components
    /// </summary>
    public abstract class ActiveComponentBase : ComponentBase, IDisposable
    {
        /// <summary>
        /// </summary>
        /// <param name="channelsCollection"></param>
        protected ActiveComponentBase(IChannelsCollection channelsCollection)
            : this(new ChannelCollectionSelector(channelsCollection))
        {
        }

        /// <summary>
        ///     Initializes an active component.
        /// </summary>
        protected ActiveComponentBase()
        {
            ComponentType = EComponentType.Active;
        }

        /// <summary>
        /// </summary>
        /// <param name="subComponents"></param>
        protected ActiveComponentBase(IEnumerable<IComponent> subComponents)
            : base(subComponents)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="channelsConnector"></param>
        /// <param name="subComponents"></param>
        protected ActiveComponentBase(IChannelsConnector channelsConnector, IEnumerable<IComponent> subComponents)
            : base(channelsConnector, subComponents)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="channelsConnector"></param>
        protected ActiveComponentBase(IChannelsConnector channelsConnector) : base(channelsConnector)
        {
        }

        /// <summary>
        /// </summary>
        public IChannelsCollection Channels { get; set; }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Request Cancellation on all threads
            // Stop & dispose all active subcomponents
            // GarbageCollect
        }

        /// <summary>
        ///     Passes the inValue to the given channel.
        /// </summary>
        /// <param name="channelName"></param>
        /// <param name="inValue"></param>
        /// <returns></returns>
        public object Execute(string channelName, params object[] inValue)
        {
            var channelsConnector = GetChannelsConnector(channelName);
            List<object> outValues, inValues = inValue.ToList();
            channelsConnector.Execute(channelName, inValues, out outValues);
            return outValues;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="channelName"></param>
        /// <param name="inValues"></param>
        /// <returns></returns>
        public Task<object> ExecuteAsync(string channelName, params object[] inValues)
        {
            return Task.Run(() => Execute(channelName, inValues));
        }

        private IChannelsConnector GetChannelsConnector(string channelName)
        {
            var channelsConnector = ((IChannelsConnector)Connector);
            if (!channelsConnector.ContainsChannel(channelName))
                throw new ChannelNotFoundException(channelName);
            return channelsConnector;
        }

        /// <summary>
        ///     Returns the channel with the specified name
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns></returns>
        public IComponentChannel GetChannel(string channelName)
        {
            return Channels[channelName];
        }

        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ContainsChannel(string name)
        {
            return Channels.Contains(name);
        }

        /// <summary>
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns></returns>
        /// <exception cref="ChannelNotFoundException"></exception>
        public IChannelEnvironment GetChannelEnvironment(string channelName)
        {
            return Channels[channelName].Environment;
        }
    }
}