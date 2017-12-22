using Pdc.System.Component;
using Pdc.System.Component.Connector;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pdc.System.Sample.Components.Passive
{
    /// <summary>
    ///     ActiveComputationUnitImpl implementation of a passive n-ary component. This class defines its own connector
    ///     <see cref="PassiveConnectorImpl" /> and computation unit <see cref="PassiveComputationUnitImpl" />
    ///     and passes them as generic type parameters to the base class.
    /// </summary>
    internal class CompleteAbbreviationExtenderComponent
        : PassiveComponentBase<
            CompleteAbbreviationExtenderComponent.PassiveConnectorImpl,
            CompleteAbbreviationExtenderComponent.PassiveComputationUnitImpl>
    {
        /// <summary>
        ///     The passive computation unit of this component
        /// </summary>
        internal class PassiveComputationUnitImpl : IPassiveComputationUnit
        {
            /// <summary>
            ///     The abbreviations this component will replace
            /// </summary>
            private readonly Dictionary<string, string> _known = new Dictionary<string, string>
            {
                {"IATA", "internationalAirTrafficAgency"},
                {"JFK", "John Fitzgerald Kennedy"}
            };

            /// <summary>
            ///     ActiveComputationUnitImpl implementation for the invoke method.
            ///     We iterate over all inValues and replace known abbreviations with their written out form
            /// </summary>
            /// <param name="inValues"></param>
            /// <param name="outValues"></param>
            public void Invoke(List<object> inValues, out List<object> outValues)
            {
                // we need to assign outValues here because IConnector.Execute
                // requires us to pass outValues by reference (out modifier)
                outValues = new List<object>();

                // after this, we can do with outValues whatever we want...
                for (var index = 0; index < inValues.Count; index++)
                {
                    var inValue = inValues[index];
                    object outValue;

                    //we can f.e.
                    if (index % 2 == 0)
                    {
                        //assign an outValue by reference (which is faster)
                        ReplaceByReference(inValue, out outValue);
                    }
                    else
                    {
                        //or assign by value (which is slower but maybe more familiar to most)
                        outValue = ReplaceByValue(inValue);
                    }
                    outValues.Add(outValue);
                }
            }

            /// <summary>
            ///     ActiveComputationUnitImpl method 1 where the input values are passed by reference (faster)
            /// </summary>
            /// <param name="str"></param>
            /// <param name="result"></param>
            private void ReplaceByReference(object str, out object result)
            {
                try
                {
                    result = _known.Aggregate((string)str, (current, abb) => current.Replace(abb.Key, abb.Value));
                }
                catch (InvalidCastException)
                {
                    result = str;
                }
            }

            /// <summary>
            ///     ActiveComputationUnitImpl method 2 where the input parameters are passed by value (slower)
            /// </summary>
            /// <param name="str"></param>
            /// <returns></returns>
            private object ReplaceByValue(object str)
            {
                try
                {
                    return _known.Aggregate((string)str, (current, abb) => current.Replace(abb.Key, abb.Value));
                }
                catch (InvalidCastException)
                {
                    return str;
                }
            }
        }

        internal class PassiveConnectorImpl : IConnector
        {
            private PassiveComponentBase _component;

            /// <summary>
            /// </summary>
            /// <param name="name">We don't need this parameter, so we will throw an exception if it was assigned a value</param>
            /// <param name="inValues">Contains the abbreviated values (IATA & JFK)</param>
            /// <param name="outValues">Contains the written out values</param>
            public void Execute(string name, List<object> inValues, out List<object> outValues)
            {
                if (!string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException(nameof(name));

                // now we call the only computation unit we know:
                _component.PassiveComputationUnit.Invoke(inValues, out outValues);
            }

            /// <summary>
            ///     Binds the connector to the given component
            /// </summary>
            /// <param name="component">The component this connector belongs to</param>
            public void Bind(IComponent component)
            {
                _component = (PassiveComponentBase)component;
            }
        }
    }
}