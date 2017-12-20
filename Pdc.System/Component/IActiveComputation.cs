using System.Collections.Generic;
using System.ServiceModel.Configuration;
using System.Threading.Tasks;
using Pdc.System.Component.Connector;

namespace Pdc.System.Component
{
    /// <summary>
    ///     Performs computation on its own thread and periodically interacts with the channels connector to pass control signals and perform data i/o.
    /// </summary>
    public interface IActiveComputationUnit
    {
        // InteractionTimer
        // CommunicatingSequentialProcessCollection CSPCollection
        // 

        /// <summary>
        /// 
        /// </summary>
        Task<List<object>> Invoke(List<object> inValues);
    }
}