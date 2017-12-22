using Newtonsoft.Json;

namespace Pdc.System.Sample
{
    public partial class GeoInfo
    {
        [JsonProperty("postalCodes")]
        public PostalCode[] PostalCodes { get; set; }
    }

    public partial class PostalCode
    {
        [JsonProperty("adminCode2")]
        public string AdminCode2 { get; set; }

        [JsonProperty("adminCode3")]
        public string AdminCode3 { get; set; }

        [JsonProperty("adminName3")]
        public string AdminName3 { get; set; }

        [JsonProperty("adminCode1")]
        public string AdminCode1 { get; set; }

        [JsonProperty("adminName2")]
        public string AdminName2 { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("postalCode")]
        public string PurplePostalCode { get; set; }

        [JsonProperty("adminName1")]
        public string AdminName1 { get; set; }

        [JsonProperty("ISO3166-2")]
        public string Iso31662 { get; set; }

        [JsonProperty("placeName")]
        public string PlaceName { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }
    }

    public class AirportInfo
    {
        [JsonProperty("delay")]
        public bool Delay { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }
}