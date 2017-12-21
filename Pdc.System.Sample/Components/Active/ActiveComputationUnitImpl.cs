using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Pdc.System.Component;

namespace Pdc.System.Sample.Components.Active
{
    /// <summary>
    /// </summary>
    public class ActiveComputationUnitImpl : AsyncHttpClientOperation, IActiveComputationUnit
    {
        private const string _ROUTE = "http://services.faa.gov/airport/status";

        public ActiveComputationUnitImpl()
            //#refactor extract superclass (HttpComputationUnit<JsonClientHeaderValues> or s.l.t.) 
            //and let it initialize the AsyncHttpClientOperation
            : base(new HttpClient(), new JsonClientHeaderValues())
        {
        }
        
        /// <summary>
        /// </summary>
        public async Task<List<object>> Invoke(List<object> inValues)
        {
            var outValues = new List<object>();

            foreach (var parameter in inValues.Cast<string>())
            {
                await CallRestApi(_ROUTE, parameter)
                    .ContinueWith(responseTask =>
                    {
                        if (responseTask.Exception == null)
                        {
                            outValues.Add(responseTask.Result);
                        }
                        else
                        {
                            outValues.Add("The computation finished with an error.");
                        }
                    });
            }
            return outValues;
        }
    }
}