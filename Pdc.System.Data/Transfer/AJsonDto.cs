using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Pdc.Serialization.Json;

namespace Pdc.System.Data.Transfer
{
    /// <summary>
    ///     Inherit from this class if you want to send / receive this class as JSON string
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AJsonDto<T> : ISerializable where T : class
    {
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }
            GetObjectData(info, context);
        }

        /// <summary>
        /// Deserialize from JSON object. 
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T FromJson(string json) => json.ToInstance<T>();

        /// <summary>
        /// Deserialize from JSON array.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static List<T> FromJsonArray(string json) => json.ToList<T>();

        /// <summary>
        /// Serialize to JSON.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string ToJson(T obj, Formatting format = Formatting.None) => obj.ToJson(format);

        /// <summary>
        /// Calls ToJson() on the current object and adds the resulting string to the SerializationInfo
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Json", this.ToJson());
        }
    }
}