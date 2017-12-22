using System.Data.Entity.Migrations;

namespace Pdc.System.Data.Test.Migrations
{
    public partial class step45 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Leads", name: "ADR", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.Leads", name: "LEAD_ID", newName: "ADR");
            RenameColumn(table: "dbo.Leads", name: "__mig_tmp__0", newName: "LEAD_ID");
        }

        public override void Down()
        {
            RenameColumn(table: "dbo.Leads", name: "LEAD_ID", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.Leads", name: "ADR", newName: "LEAD_ID");
            RenameColumn(table: "dbo.Leads", name: "__mig_tmp__0", newName: "ADR");
        }
    }
}