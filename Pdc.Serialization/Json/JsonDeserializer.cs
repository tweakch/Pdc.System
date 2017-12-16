using Newtonsoft.Json;

namespace Pdc.Serialization.Json
{
    /// <summary>
    ///     Helper class that deserializes a string to an object of type T using Newtonsoft.JsonConvert
    /// </summary>
    internal static class JsonDeserializer
    {
        public static T ToInstance<T>(this string self)
            => JsonConvert.DeserializeObject<T>(self, JsonConverter.Settings);
    }
}