
using System;
using System.Data.Entity.Migrations;

namespace Pdc.System.Data.Test.Migrations
{
    
    public partial class step3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Leads", name: "Processing", newName: "PDC_VERARB_FLAG");
            RenameColumn(table: "dbo.Leads", name: "LeadId", newName: "ADR");
            RenameColumn(table: "dbo.Leads", name: "Adresse", newName: "LEAD_ID");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Leads", name: "LEAD_ID", newName: "Adresse");
            RenameColumn(table: "dbo.Leads", name: "ADR", newName: "LeadId");
            RenameColumn(table: "dbo.Leads", name: "PDC_VERARB_FLAG", newName: "Processing");
        }
    }
}
