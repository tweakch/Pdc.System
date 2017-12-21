using System.Collections.Generic;
using System.Linq;
using Pdc.Serialization.Json;
using Pdc.System.Component;
using Pdc.System.Sample.Components.Connectors;

namespace Pdc.System.Sample.Components.Active
{
    //public class UnaryAirportInfoComponent : ActiveUnaryComponent<string>
    //{
    //}

    /// <summary>
    ///     Active Component capable of providing US Airport information.
    /// </summary>
    public class AirportInfoComponent : ActiveComponentBase
    {
        public AirportInfoComponent() : base(new AirportInfoChannelsSelector())
        {
        }

        /// <summary>
        ///     Initializes the AirportInfoComponent, and passes the IATA code to the FAA Airport Service API channel.
        /// </summary>
        /// <param name="iata">IATA code of the airport</param>
        /// <returns>JSON data for the airport.</returns>
        public static string Execute(string iata)
        {
            using (var component = new AirportInfoComponent())
            {
                List<object> outValue;
                var inValues = new List<object> {iata};
                component.Connector.Execute(SampleChannelCollection.FAA_API, inValues, out outValue);
                return outValue.Single().ToString();
            }
        }

        /// <summary>
        ///     <para>
        ///         Initializes tha AirportInfoComponent and passes the IATA code to the FAA Airport Service API channel.
        ///         Upon completion, the <see cref="JsonExtensions.ToInstance{T}" /> method will map the json to the provided type.
        ///     </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="iata">IATA code of the airport</param>
        /// <returns></returns>
        public static T Execute<T>(string iata) where T : class
        {
            var executeResult = Execute(iata);
            var instance = executeResult.ToInstance<T>();
            return instance;
        }
    }
}