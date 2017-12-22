using Pdc.System.Component;
using Pdc.System.Sample.Components.Active;

namespace Pdc.System.Sample.Components
{
    /// <summary>
    /// </summary>
    public class AirportInfoChannelCollection : ComponentChannelCollection
    {
        public const string FAA_API = "FAA Airport Service API";
        public const string HAU_API = "Hausens Geile Kleine API";

        /// <summary>
        /// </summary>
        public AirportInfoChannelCollection()
        {
            AddChannel<FaaServicesApiComputationUnit>(FAA_API);
            AddChannel<HausenApiComponentUnit>(HAU_API);
        }
    }
}