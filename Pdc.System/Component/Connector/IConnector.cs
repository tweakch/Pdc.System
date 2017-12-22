using System;
using System.Collections.Generic;

namespace Pdc.System.Component.Connector
{
    /// <summary>
    ///     Provides the interface for the typesafe component
    /// </summary>
    public interface IConnector<TIn, TOut> : IConnector
    {
        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="inValues"></param>
        /// <param name="outValues"></param>
        void Execute(string name, List<TIn> inValues, out List<TOut> outValues);
    }

    /// <summary>
    ///     Provides the interface for the typesafe component
    /// </summary>
    public interface IConnector<T> : IConnector
    {
        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="inValues"></param>
        /// <param name="outValues"></param>
        void Execute(string name, List<T> inValues, out List<T> outValues);
    }

    /// <summary>
    ///     Provides the interface for the component
    /// </summary>
    public interface IConnector
    {
        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="inValues"></param>
        /// <param name="outValues"></param>
        void Execute(string name, List<object> inValues, out List<object> outValues);

        /// <summary>
        /// Binds the connector to the given component
        /// </summary>
        /// <param name="component">The component this connector belongs to</param>
        void Bind(IComponent component);
    }

    /// <summary>
    ///
    /// </summary>
    public class ConnectorEventArgs : EventArgs
    {
        private List<object> inValues;
        private List<object> outValues;

        /// <summary>
        ///
        /// </summary>
        /// <param name="inValues"></param>
        /// <param name="outValues"></param>
        public ConnectorEventArgs(List<object> inValues, List<object> outValues)
        {
            this.inValues = inValues;
            this.outValues = outValues;
        }
    }
}