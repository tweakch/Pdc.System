using Pdc.System.Component;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pdc.System.Sample.Components.Active
{
    public class PostalCodeComputationUnit : HttpComputationUnit<JsonClientSettings>
    {
        private string _ROUTE = "http://api.geonames.org/postalCodeSearchJSON?";

        public override async Task<List<object>> Invoke(List<object> inValues)
        {
            var username = inValues[0].ToString();
            var sessionId = inValues[1].ToString();
            var postalCode = inValues[2].ToString();

            var outValues = new List<object>();
            Client.DefaultRequestHeaders.Add("JSESSIONID", sessionId);

            var parameter = $"postalcode={postalCode}&country=CH&username={username}";

            await RestGet(_ROUTE, parameter)
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