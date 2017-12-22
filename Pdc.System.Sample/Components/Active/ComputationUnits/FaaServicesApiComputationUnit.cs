using Pdc.System.Component;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pdc.System.Sample.Components.Active
{
    /// <summary>
    /// </summary>
    public class FaaServicesApiComputationUnit : HttpComputationUnit<JsonClientSettings>
    {
        private const string _ROUTE = "http://services.faa.gov/airport/status";

        /// <summary>
        /// </summary>
        public override async Task<List<object>> Invoke(List<object> inValues)
        {
            var outValues = new List<object>();

            foreach (var parameter in inValues.Cast<string>())
            {
                await RestGet(_ROUTE, parameter)
                    .ContinueWith(responseTask =>
                    {
                        if (responseTask.IsCanceled) outValues.Add(CANCELLED_BY_USER);
                        if (responseTask.IsFaulted) outValues.Add(responseTask.Exception);
                        if (responseTask.IsCompleted) outValues.Add(responseTask.Result);
                    });
            }
            return outValues;
        }
    }

    public class HausenApiComponentUnit : HttpComputationUnit<JsonClientSettings>
    {
        private string _ROUTE = "http://services.faa.gov/airport/status";

        public override async Task<List<object>> Invoke(List<object> inValues)
        {
            var outValues = new List<object>();

            foreach (var parameter in inValues.Cast<string>())
            {
                await RestGet(_ROUTE, parameter)
                    .ContinueWith(responseTask =>
                    {
                        if (responseTask.IsCanceled) outValues.Add(CANCELLED_BY_USER);
                        if (responseTask.IsFaulted) outValues.Add(responseTask.Exception);
                        if (responseTask.IsCompleted) outValues.Add(responseTask.Result);
                    });
            }
            return outValues;
        }
    }
}