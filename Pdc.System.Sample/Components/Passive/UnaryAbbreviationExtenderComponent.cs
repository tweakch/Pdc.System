using Pdc.System.Component;

namespace Pdc.System.Sample.Components.Passive
{
    /// <summary>
    ///     ActiveComputationUnitImpl implementation of a passive unary component
    /// </summary>
    public class UnaryAbbreviationExtenderComponent : PassiveUnaryComponent<string>
    {
        /// <summary>
        ///
        /// </summary>
        public UnaryAbbreviationExtenderComponent() : base(Execute)
        {
        }

        /// <summary>
        /// The unary computation unit of the component
        /// </summary>
        /// <param name="inValue"></param>
        /// <param name="outValue"></param>
        public static void Execute(string inValue, out string outValue)
        {
            outValue = inValue
                .Replace("IATA", "internationalAirTrafficAgency")
                .Replace("JFK", "John Fitzgerald Kennedy");
        }
    }
}