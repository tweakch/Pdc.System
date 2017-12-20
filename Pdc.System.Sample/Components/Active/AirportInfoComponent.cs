using System;
using System.Collections.Generic;
using System.Linq;
using Pdc.Serialization.Json;
using Pdc.System.Component;
using Pdc.System.Component.Connector;
using Pdc.System.Sample.Components.Connectors;

namespace Pdc.System.Sample.Components.Active
{
    //internal class UnaryAirportInfoComponent : ActiveUnaryComponent<string>
    //{
    //}

    internal class AirportInfoComponent : ActiveComponentBase
    {
        public AirportInfoComponent() : base(new AirportInfoChannelsSelector())
        {
        }

        /// <summary>
        /// Helper method that initializes the AirportInfoComponent, and passes the input value to the "FAA Airport Service API" channel.
        /// </summary>
        /// <param name="inValue"></param>
        /// <returns></returns>
        public static string Execute(string inValue)
        {
            using (var component = new AirportInfoComponent())
            {
                List<object> outValue;
                var inValues = new List<object> { inValue };
                component.Connector.Execute(SampleChannelCollection.FAA_API, inValues, out outValue);
                return outValue.Single().ToString();
            }
        }
        
        public static T Execute<T>(string inValue) where T : class
        {
            var executeResult = Execute(inValue);
            var instance = executeResult.ToInstance<T>();
            return instance;
        }
    }
}