using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Pdc.System.Data.Transfer;

namespace Pdc.System.Data.Test
{
    /// <summary>
    /// Represents a lead entity
    /// </summary>
    public class Lead : AJsonDto<Lead>, ISerializeLead
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("PDC_VERARB_FLAG")]
        public int Processing { get; set; }

        [Column("LEAD_ID")]
        public string LeadId { get; set; }

        [Column("ADR", Order = 2)]
        public string Adresse { get; set; }
    }

    public class Request : AJsonDto<Request>, ISerializeRequest
    {
        public int Id { get; set; }
        public int PDC_VERARB_FLAG { get; set; }
        public string Headers { get; set; }
        public string Body { get; set; }
    }

    public class TestContext : DbContext
    {
        private const string _CONNECTION_STRING =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public TestContext() : base(_CONNECTION_STRING)
        {
        }

        public DbSet<Lead> Leads { get; set; }
        public DbSet<Request> Requests { get; set; }
    }
}