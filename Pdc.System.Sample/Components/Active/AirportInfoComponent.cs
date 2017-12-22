using Pdc.Serialization.Json;
using Pdc.System.Component;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public AirportInfoComponent()
            : base(new AirportInfoChannelCollection())
        {
        }

        /// <summary>
        ///     Initializes the AirportInfoComponent and retreives airport status via IATA code
        /// </summary>
        /// <param name="iata">IATA code of the airport</param>
        /// <returns>JSON data for the airport.</returns>
        public static object Execute(string iata)
        {
            // active components should only be accessed within using blocks
            // to free ChannelEnvironments and ComputationUnits automatically
            using (var component = new AirportInfoComponent())
            {
                var execute = component.Execute(AirportInfoChannelCollection.FAA_API, iata) as List<object>;
                return execute[0];
            }
        }

        public static async Task<string> ExecuteAsync(string iata)
        {
            using (var component = new AirportInfoComponent())
            {
                var asyncResult = await component.
                    ExecuteAsync(AirportInfoChannelCollection.FAA_API, iata).
                    ContinueWith(taskResult => (string)taskResult.Result);
                return asyncResult;
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
            var instance = ((string)executeResult).ToInstance<T>();
            return instance;
        }
    }
}