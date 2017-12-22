using Newtonsoft.Json;
using System;

namespace Pdc.Serialization.Json
{
    /// <summary>
    ///     Helper class that deserializes a string to an object of type T using Newtonsoft.JsonConvert
    /// </summary>
    internal static class JsonDeserializer
    {
        public static T ToInstance<T>(this string self)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(self, JsonConverter.Settings);
            }
            catch (Exception)
            {
                return default(T);
            }
        }
    }
}