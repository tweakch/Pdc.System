using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Pdc.System.Component;

namespace Pdc.System.Sample.Components.Active
{
    /// <summary>
    /// 
    /// </summary>
    public class ActiveComputationUnitImpl : IActiveComputationUnit
    {
        /// <summary>
        /// 
        /// </summary>
        public async Task<List<object>> Invoke(List<object> inValues)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var outValues = new List<object>();
            foreach (var inValue in inValues)
            {
                var stringAsync = await client.GetStringAsync($"http://services.faa.gov/airport/status/{inValue}");
                outValues.Add(stringAsync);
            }

            //client.SendAsync(request)
            //.ContinueWith(responseTask =>
            // {
            //     Console.WriteLine("Response: {0}", responseTask.Result);
            // });
            return outValues;
        }
    }
}