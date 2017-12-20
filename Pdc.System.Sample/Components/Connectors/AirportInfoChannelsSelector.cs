using System.Collections.Generic;
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
        ///     Passes the inValues to the specified channels environment and waits for the channel to complete the operation.
        ///     If the channel does not exist outValues will return null.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="inValues"></param>
        /// <param name="outValues"></param>
        public override void Execute(string name, List<object> inValues, out List<object> outValues)
        {
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
    }
}