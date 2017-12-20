using System.Collections.Generic;

namespace Pdc.System.Component.Connector
{
    /// <summary>
    /// 
    /// </summary>
    public class NullConnector : IConnector
    {
        private IComponent _component;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="inValues"></param>
        /// <param name="outValues"></param>
        public void Execute(string name, List<object> inValues, out List<object> outValues)
        {
            outValues = null;
        }


        /// <summary>
        /// Binds the connector to the given component
        /// </summary>
        /// <param name="component">The component this connector belongs to</param>
        public void Bind(IComponent component)
        {
            _component = component;
        }
    }
}