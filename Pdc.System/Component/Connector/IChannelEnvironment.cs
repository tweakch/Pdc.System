using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pdc.System.Component.Connector
{
    /// <summary>
    /// 
    /// </summary>
    public interface IChannelEnvironment
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inValues"></param>
        Task<List<object>> SetInputValues(List<object> inValues);
    }
}