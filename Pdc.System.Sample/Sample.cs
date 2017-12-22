using Pdc.Serialization.Json;
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
            var sequence = PipeConnector.CreateSequence<AirportInfoComponent, UnaryAbbreviationExtenderComponent>();
            var example = sequence.Execute("JFK");
            // example = {"delay":"true","internationalAirTransportAssociation":"John Fitzgerald Kennedy...

            var username = "demo";
            var password = "password";
            var sessionId = GeoNamesPostalCodesComponent.Login(username, password);
            var result = (string)GeoNamesPostalCodesComponent.PostalCode(username, sessionId, "8001");

            var geo = result.ToInstance<GeoInfo>();
        }
    }
}