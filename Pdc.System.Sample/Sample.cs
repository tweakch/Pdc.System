using System.Reflection.Emit;
using Newtonsoft.Json;
using Pdc.System.Component.Connector;
using Pdc.System.Sample.Components.Active;
using Pdc.System.Sample.Components.Passive;

namespace Pdc.System.Sample
{
    internal class Sample
    {
        private static void Main(string[] args)
        {
            // receive raw airport data
            var info = AirportInfoComponent.Execute("JFK");
            // {"delay":"true","IATA":"JFK"...

            // directly map results to your classes
            var delay = AirportInfoComponent.Execute<AirportInfo>("JFK").Delay;
            // true
            
            // string components together
            var sequence = PipeConnector.Sequence<AirportInfoComponent, UnaryAbbreviationExtenderComponent>();
            var example = sequence.Execute("JFK");
            // example = {"delay":"true","internationalAirTransportAssociation":"John Fitzgerald Kennedy...
        }
    }
    public class AirportInfo
    {
        [JsonProperty]
        public bool Delay { get; set; }

        [JsonProperty]
        public string State { get; set; }
    }
}