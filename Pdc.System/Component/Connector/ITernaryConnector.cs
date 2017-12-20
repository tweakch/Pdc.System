using System;

namespace Pdc.System.Component.Connector
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITernaryConnector
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inValues"></param>
        /// <param name="outValues"></param>
        void Execute(Tuple<object, object, object> inValues, out Tuple<object, object, object> outValues);
    }
}