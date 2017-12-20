using System;
using System.Reflection;
using AutoMapper.Configuration.Conventions;
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
            ContractResolver = new PdcPropertyNamesContractResolver();
            DateFormatString = "O"; // ISO 8601 2017-12-21T10:00:00.1234+01:00
            Formatting = Formatting.Indented;
            DateParseHandling = DateParseHandling.None;
        }
    }

    public class PdcPropertyNamesContractResolver : CamelCasePropertyNamesContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            return base.CreateProperty(member, memberSerialization);
        }

        protected override string ResolvePropertyName(string propertyName)
        {
            return base.ResolvePropertyName(propertyName);
        }
    }
}