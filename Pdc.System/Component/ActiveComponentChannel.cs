using Pdc.System.Component.Connector;

namespace Pdc.System.Component
{
    /// <summary>
    ///
    /// </summary>
    public class ActiveComponentChannel : IComponentChannel
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        public ActiveComponentChannel(string name, IActiveComputationUnit unit)
        {
            Name = name;
            Environment = new ChannelEnvironment(unit);
        }

        /// <summary>
        ///     The name of the channel
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The environment of the channel
        /// </summary>
        /// <value></value>
        public IChannelEnvironment Environment { get; private set; }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// <see langword="true"/> if the current object is equal to the <paramref name="other"/> parameter; otherwise, <see langword="false"/>.
        /// </returns>
        public bool Equals(IComponentChannel other)
        {
            return other != null && Name.Equals(other.Name);
        }
    }
}