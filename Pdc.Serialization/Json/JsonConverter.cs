using Newtonsoft.Json;

namespace Pdc.Serialization.Json
{
    internal class JsonConverter
    {
        public static readonly JsonSerializerSettings Settings = new GoogleStyleguideSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None
        };
    }
}