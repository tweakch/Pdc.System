using System.Collections.Generic;
using System.Threading.Tasks;

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