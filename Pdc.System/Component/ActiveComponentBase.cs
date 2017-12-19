using System.Collections.Generic;

namespace Pdc.System.Component
{
    /// <summary>
    ///     Abstract base class for all Active Components
    /// </summary>
    public abstract class ActiveComponentBase : ComponentBase
    {
        /// <summary>
        ///     Initializes an active component.
        /// </summary>
        protected ActiveComponentBase()
        {
            ComponentTypeType = EComponentType.Active;
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
            : base(subComponents)
        {
            ChannelsConnector = channelsConnector;
        }
        
        /// <summary>
        /// </summary>
        /// <param name="channelsConnector"></param>
        protected ActiveComponentBase(IChannelsConnector channelsConnector)
        {
            ChannelsConnector = channelsConnector;
        }

        /// <summary>
        /// </summary>
        public IChannelsConnector ChannelsConnector { get; set; }
    }
}