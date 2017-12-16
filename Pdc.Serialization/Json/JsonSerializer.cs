using Newtonsoft.Json;

namespace Pdc.Serialization.Json
{
    internal static class JsonSerializer
    {
        public static string ToJson(this object self, Formatting formatting = Formatting.None)
            => JsonConvert.SerializeObject(self, formatting, JsonConverter.Settings);
    }
}