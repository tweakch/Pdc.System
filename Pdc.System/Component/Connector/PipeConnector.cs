using System;
using System.Collections.Generic;

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
        public static PipeConnector CreateSequence<T1, T2>()
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
                if (component.IsActive)
                {
                    outValues = AggregateChannelOutputs(inValues, component);
                }
                else
                {
                    InvokeChannelOnConnector(inValues, component, string.Empty, out outValues);
                }
                // set the inValues for the next component
                inValues = outValues;
            }
            return outValues;
        }

        private static List<object> AggregateChannelOutputs(List<object> inValues, IComponent component)
        {
            List<object> outValues;
            var channelOut = new List<object>();
            var activeComponent = component as ActiveComponentBase;
            foreach (var channel in activeComponent.Channels)
            {
                InvokeChannelOnConnector(inValues, component, channel.Name, out outValues);
                channelOut.AddRange(outValues);
            }
            outValues = channelOut;
            return outValues;
        }

        private static void InvokeChannelOnConnector(List<object> inValues, IComponent component, string channelName, out List<object> outValues)
        {
            component.Connector.Execute(channelName, inValues, out outValues);
        }
    }

    /// <summary>
    ///
    /// </summary>
    public abstract class ACompositionOperator
    {
    }
}