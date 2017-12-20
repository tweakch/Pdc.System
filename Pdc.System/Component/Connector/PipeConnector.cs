using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pdc.System.Component.Connector
{
    /// <summary>
    /// Passive Component Operator
    /// </summary>
    public class PipeConnector : ACompositionOperator
    {
        private readonly List<IComponent> _sequence;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sequence"></param>
        public PipeConnector(List<IComponent> sequence)
        {
            this._sequence = sequence;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static PipeConnector Sequence<T1, T2>() 
            where T1 : IComponent 
            where T2 : IComponent
        {
            var sequence = new List<IComponent>
            {
                Activator.CreateInstance<T1>(),
                Activator.CreateInstance<T2>()
            };

            var pipeConnector = new PipeConnector(sequence);
            return pipeConnector;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public object Execute(params object[] param)
        {
            List<object> inValues = new List<object>();
            List<object> outValues = null;
            inValues.AddRange(param);

            foreach (var component in _sequence)
            {
                component.Connector.Execute("", inValues, out outValues);
                inValues = outValues;
            }
            return outValues;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class ACompositionOperator
    {
    }
}
