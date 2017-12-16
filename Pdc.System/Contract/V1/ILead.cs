using Newtonsoft.Json;

namespace Pdc.System.Contract.V1
{

    interface ILead
    {
        int Id { get; set; }

        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        int LeadId { get; set; }

        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        string Name { get; set; }
    }
}
