using System;
using System.Collections.Generic;
using System.Linq;
using Pdc.System.Component.Connector;

namespace Pdc.System.Sample.Components.Connectors
{
    /// <summary>
    ///     Passive component
    /// </summary>
    internal class AirportInfoChannelsSelector : DefaultChannelsSelector
    {
        public AirportInfoChannelsSelector() : base(new SampleChannelCollection())
        {
        }

        /// <summary>
        ///     <para>
        ///         Passes the inValues to the specified channels environment and waits for the channel to complete the
        ///         operation.
        ///     
        ///     If the channel does not exist outValues will return null.
        ///     If name is empty, the channel selector will look for a single channel on the component. 
        /// </para>
        /// <para>Exceptions: 
        ///     Throws If there is more than one channel defined, an Exception is thrown.</para>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="inValues"></param>
        /// <param name="outValues"></param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception><exception cref="T:System.InvalidOperationException">The input sequence contains more than one element.-or-The input sequence is empty.</exception>
        public override void Execute(string name, List<object> inValues, out List<object> outValues)
        {
            name = ResolveChannelName(name);

            if (Component.ContainsChannel(name))
            {
                // we get the channel environemnt
                var environment = Component.GetChannelEnvironment(name);

                // by setting the input values we receive an awaitable operation
                var channelOperation = environment.SetInputValues(inValues);

                // we wait for the operation to finish
                channelOperation.Wait();

                // and assign to result of the task the outValues
                outValues = channelOperation.Result;
            }
            else
            {
                outValues = null;
            }
        }

        private string ResolveChannelName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (name.Equals(string.Empty))
            {
                name = Component.Channels.Single().Name;
            }
            return name;
        }
    }
}