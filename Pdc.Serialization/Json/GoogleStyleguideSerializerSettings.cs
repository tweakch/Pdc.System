using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pdc.Serialization.Json
{
    /// <summary>
    ///     These guidelines allow JavaScript clients to access properties using dot notation. (for example, result.thisIsAnInstanceVariable).
    /// </summary>
    public class GoogleStyleguideSerializerSettings : JsonSerializerSettings
    {
        public GoogleStyleguideSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver();
            DateFormatString = "O"; // ISO 8601
            Formatting = Formatting.Indented;
        }
    }
}