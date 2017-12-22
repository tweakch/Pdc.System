using System.Collections.Generic;

namespace Pdc.System.Component
{
    /// <summary>
    ///
    /// </summary>
    public interface IPassiveComputationUnit
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="inValues"></param>
        /// <param name="outValues"></param>
        void Invoke(List<object> inValues, out List<object> outValues);
    }
}