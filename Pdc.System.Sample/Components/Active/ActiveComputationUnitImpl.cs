using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Pdc.System.Component;

namespace Pdc.System.Sample.Components.Active
{
    /// <summary>
    /// 
    /// </summary>
    public class ActiveComputationUnitImpl : IActiveComputationUnit
    {
        private readonly string jfkJson =
            "{\"delay\":\"true\",\"IATA\":\"JFK\",\"state\":\"New York\",\"name\":\"John F Kennedy International\",\"weather\":{\"visibility\":10,\"weather\":\"Mostly Cloudy\",\"meta\":{\"credit\":\"NOAA's National Weather Service\",\"updated\":\"6:51 AM Local\",\"url\":\"http://weather.gov/\"},\"temp\":\"43.0 F (6.1 C)\",\"wind\":\"West at 10.4mph\"},\"ICAO\":\"Kjfk\",\"city\":\"New York\",\"status\":{\"reason\":\"No known delays for this airport.\",\"closureBegin\":\"\",\"endTime\":\"\",\"minDelay\":\"\",\"avgDelay\":\"\",\"maxDelay\":\"\",\"closureEnd\":\"\",\"trend\":\"\",\"type\":\"\"}}";

        /// <summary>
        /// 
        /// </summary>
        public async Task<List<object>> Invoke(List<object> inValues)
        {
            HttpClient client = new HttpClient();
            
            var outValues = new List<object>();

            foreach (var inValue in inValues)
            {
                var stringAsync = await client.GetStringAsync($"http://services.faa.gov/airport/status/{inValue}");
                outValues.Add(stringAsync);
            }
            return outValues;
        }
    }
}