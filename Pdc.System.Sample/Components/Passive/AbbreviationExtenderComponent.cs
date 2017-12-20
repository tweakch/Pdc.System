using Pdc.System.Component;

namespace Pdc.System.Sample.Components.Passive
{
    /// <summary>
    ///     ActiveComputationUnitImpl implementation of a passive unary component
    /// </summary>
    internal class AbbreviationExtenderComponent : PassiveUnaryComponent<string>
    {
        public AbbreviationExtenderComponent() : base(Compute)
        {
        }

        public static void Compute(string inValue, out string outValue)
        {
            outValue = inValue
                .Replace("IATA", "internationalAirTrafficAgency")
                .Replace("JFK", "John Fitzgerald Kennedy");
        }
    }
}