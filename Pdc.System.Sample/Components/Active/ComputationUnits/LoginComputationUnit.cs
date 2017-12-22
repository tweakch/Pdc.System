using Pdc.System.Component;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pdc.System.Sample.Components.Active
{
    public class LoginComputationUnit : HttpComputationUnit<JsonClientSettings>
    {
        public override async Task<List<object>> Invoke(List<object> inValues)
        {
            var outValues = new List<object>();
            var loginParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", inValues[0].ToString()),
                new KeyValuePair<string, string>("password", inValues[1].ToString())
            };

            await RestPost("http://www.geonames.org/servlet/geonames?", loginParams)
                .ContinueWith(responseTask =>
                {
                    if (responseTask.IsCanceled) outValues.Add(CANCELLED_BY_USER);
                    if (responseTask.IsFaulted) outValues.Add(responseTask.Exception);
                    if (responseTask.IsCompleted) outValues.Add(responseTask.Result);
                });

            return outValues;
        }
    }
}