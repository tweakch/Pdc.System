namespace Pdc.System.Data.Test
{
    using Newtonsoft.Json;

    public interface ISerializeRequest
    {
        int Id { get; set; }
        int PDC_VERARB_FLAG { get; set; }

        [JsonProperty("headers")]
        string Headers { get; set; }

        [JsonProperty("body")]
        string Body { get; set; }
    }
}