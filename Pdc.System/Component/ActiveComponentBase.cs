using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.ServiceModel;
using Pdc.System.Component.Connector;

namespace Pdc.System.Component
{
    /// <summary>
    ///     Abstract base class for all Active Components
    /// </summary>
    public abstract class ActiveComponentBase : ComponentBase, IDisposable
    {
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
        /// 
        /// </summary>
        public IChannelsCollection Channels { get; set; }
        
        /// <summary>
        /// </summary>
        /// <param name="channelsConnector"></param>
        protected ActiveComponentBase(IChannelsConnector channelsConnector) : base(channelsConnector)
        {
        }

        /// <summary>
        ///     Passes the inValue to the given channel.
        /// </summary>
        /// <param name="channelName"></param>
        /// <param name="inValue"></param>
        /// <returns></returns>
        public object Execute(string channelName, params object[] inValue)
        {          
            var channelsConnector = ((IChannelsConnector)Connector);
            if (!channelsConnector.ContainsChannel(channelName))
                throw new ChannelNotFoundException(channelName);

            List<object> outValues, inValues = inValue.ToList();
            channelsConnector.Execute(channelName, inValues, out outValues);
            return outValues;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Request Cancellation on all threads
            // Stop & dispose all active subcomponents
            // GarbageCollect
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
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ContainsChannel(string name)
        {
            return Channels.Contains(name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IChannelEnvironment GetChannelEnvironment(string channelName)
        {
            return Channels[channelName].GetEnvironment();
        }
    }
}