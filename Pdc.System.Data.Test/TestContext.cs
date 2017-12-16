using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pdc.System.Data.Test
{
    public class Lead
    {
        [Key]
        public int Id { get; set; }
        public string LeadId { get; set; }
        public string Adresse { get; set; }
    }
    public class Request
    {
        [Key]
        public int Id { get; set; }
        public string Headers { get; set; }
        public string Body { get; set; }
    }

    public class TestContext : DbContext
    {
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Request> Requests { get; set; }
    }
}
