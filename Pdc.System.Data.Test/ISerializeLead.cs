using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Pdc.System.Data.Test
{
    /// <summary>
    /// The serialization interface for a Lead
    /// </summary>
    public interface ISerializeLead
    {
        int Id { get; set; }

        int Processing { get; set; }

        [JsonProperty("address")]
        string Adresse { get; set; }

        [JsonProperty("leadId")]
        string LeadId { get; set; }
    }
}