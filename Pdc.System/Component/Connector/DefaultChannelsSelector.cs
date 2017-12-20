using System;
using System.Collections.Generic;

namespace Pdc.System.Component.Connector
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class DefaultChannelsSelector : IChannelsConnector
    {
        private readonly IChannelsCollection _channelsCollection;
        private ActiveComponentBase _component;

        /// <summary>
        /// The component the selector has been bound to
        /// </summary>
        public ActiveComponentBase Component => _component;

        /// <summary>
        /// 
        /// </summary>
        public IChannelEnvironment ChannelEnvironment { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channelsCollection"></param>
        protected DefaultChannelsSelector(IChannelsCollection channelsCollection)
        {
            _channelsCollection = channelsCollection;
        }

        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="inValues"></param>
        /// <param name="outValues"></param>
        public abstract void Execute(string name, List<object> inValues, out List<object> outValues);

        /// <summary>
        /// Binds the connector to the given component
        /// </summary>
        /// <param name="component">The component this connector belongs to</param>
        public void Bind(IComponent component)
        {
            this._component = (ActiveComponentBase) component;
            this._component.Channels = _channelsCollection;
        }

        /// <summary>
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns></returns>
        public bool ContainsChannel(string channelName)
        {
            return _component.Channels.Contains(channelName);
        }
    }
}