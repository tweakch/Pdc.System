using System;

namespace Pdc.System.Component.Connector
{
    /// <summary>
    ///
    /// </summary>
    public interface IBinaryConnector
    {
        void Execute(Tuple<object, object> inValues, out Tuple<object, object> outValues);
    }
}