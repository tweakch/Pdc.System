using Pdc.System.Component;
using System.Collections.Generic;
using System.Net.Http;

namespace Pdc.System.Sample.Components.Active
{
    /// <summary>
    /// <para>Evolving your component</para>
    /// </summary>
    public class GeoNamesPostalCodesComponent : ActiveComponentBase
    {
        public GeoNamesPostalCodesComponent() : base(new GeoNamesChannelCollection())
        {
        }

        public static object Login(string username, string password)
        {
            using (var component = new GeoNamesPostalCodesComponent())
            {
                var result = (List<object>)component.Execute("Login", username, password);
                var response = (HttpResponseMessage)result[0];
                foreach (dynamic item in response.Headers)
                {
                    if (item.Key.Equals("Set-Cookie"))
                    {
                        return item.Value[0];
                    }
                }
                return null;
            }
        }

        public static object PostalCode(string username, object sessionId, string postalCode)
        {
            using (var component = new GeoNamesPostalCodesComponent())
            {
                var result = (List<object>)component.Execute("Postal", username, sessionId, postalCode);
                var response = result[0];
                return response;
            }
        }
    }

    public class GeoNamesChannelCollection : ComponentChannelCollection
    {
        public GeoNamesChannelCollection()
        {
            AddChannel<LoginComputationUnit>("Login");
            AddChannel<PostalCodeComputationUnit>("Postal");
        }
    }
}