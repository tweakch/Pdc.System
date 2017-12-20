using System.Collections.Generic;
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

        public static JsonSerializerSettings DefaultSettings { get; set; } = JsonConverter.Settings;

        /// <summary>
        ///     Converts a JSON array of <see cref="T" /> to a strongly typed <see cref="List{T}" />
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this string json)
        {
            return JsonDeserializer.ToInstance<List<T>>(json);
        }

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
            return JsonSerializer.ToJson(obj, format);
        }

        /// <summary>
        ///     Creates an instance of T with the values in the JSON string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T ToInstance<T>(this string json)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<T,T>());
            T instance = JsonDeserializer.ToInstance<T>(json);
            return instance;
        }

        /// <summary>
        ///     Maps the values in the JSON string to the properties of T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="json"></param>
        public static void FromJson<T>(this T obj, string json) where T : class
        {
            Mapper.Initialize(cfg => cfg.CreateMap<T, T>());
            T instance = ToInstance<T>(json);
            Mapper.Map(instance, obj);
        }
    }
}