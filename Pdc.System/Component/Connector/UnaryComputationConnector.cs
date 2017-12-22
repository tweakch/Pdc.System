using System;
using System.Collections.Generic;

namespace Pdc.System.Component.Connector
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UnaryComputationConnector<T> : IUnaryConnector<T>
    {
        private PassiveUnaryComponent<T> _component;

        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="inValues"></param>
        /// <param name="outValues"></param>
        public void Execute(string name, List<object> inValues, out List<object> outValues)
        {
            try
            {
                outValues = new List<object>();
                foreach (var item in inValues)
                {
                    T outValue;
                    Execute((T)item, out outValue);
                    outValues.Add(outValue);
                }
            }
            catch (InvalidCastException)
            {
                throw new InvalidOperationException("The Typesafe Unary Computation was invoked with the wrong input values");
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Unary connector invoked with multiple values");
            }
        }

        /// <summary>
        /// Binds the connector to the given component
        /// </summary>
        /// <param name="component">The component this connector belongs to</param>
        public void Bind(IComponent component)
        {
            _component = (PassiveUnaryComponent<T>)component;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="inValue"></param>
        /// <param name="outValue"></param>
        public void Execute(T inValue, out T outValue)
        {
            _component.Computation(inValue, out outValue);
        }
    }
}