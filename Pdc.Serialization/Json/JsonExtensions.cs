using System;
using AutoMapper;
using Newtonsoft.Json;

namespace Pdc.Serialization.Json
{
    public static class JsonExtensions
    {
        static JsonExtensions()
        {
            JsonConvert.DefaultSettings = () => DefaultSettings;
        }

        public static JsonSerializerSettings DefaultSettings { get; set; } =
            Activator.CreateInstance<GoogleStyleguideSerializerSettings>();

        /// <summary>
        ///     Converts an object to JSON.
        ///     <para>
        ///         Follows the JSON style guideline from Google:
        ///         <seealso cref="https://google.github.io/styleguide/jsoncstyleguide.xml" />
        ///     </para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string ToJson(this object obj, Formatting format = Formatting.None)
        {
            return JsonConvert.SerializeObject(obj, format);
        }

        public static T ToInstance<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static void MapJson<T>(this T obj, string json) where T : class
        {
            Mapper.Initialize(cfg => cfg.CreateMap<T, T>());
            Mapper.Map(json.ToInstance<T>(), obj);
        }
    }
}