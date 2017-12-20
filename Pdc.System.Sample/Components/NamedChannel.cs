using Pdc.System.Component;
using Pdc.System.Component.Connector;
using Pdc.System.Sample.Components.Active;

namespace Pdc.System.Sample.Components
{
    /// <summary>
    /// 
    /// </summary>
    public class NamedChannel : IComponentChannel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public NamedChannel(string name)
        {
            Name = name;
        }

        /// <summary>
        ///     The name of the channel
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The environment of the channel
        /// </summary>
        /// <returns></returns>
        public IChannelEnvironment GetEnvironment()
        {
            return new NamedChannelEnvironment(new ActiveComputationUnitImpl());
        }
    }
}