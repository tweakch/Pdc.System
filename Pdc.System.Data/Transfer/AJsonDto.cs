using System.Collections.Generic;
using Newtonsoft.Json;
using Pdc.Serialization.Json;

namespace Pdc.System.Data.Transfer
{
    /// <summary>
    /// Inherit from this class if you want to send / receive this class as JSON string
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AJsonDto<T> where T : class
    {
        public static T FromJson(string json) => json.ToInstance<T>();
        public static List<T> FromJsonArray(string json) => json.ToList<T>();
        public static string ToJson(T obj, Formatting format = Formatting.None) => obj.ToJson(format);
    }
}