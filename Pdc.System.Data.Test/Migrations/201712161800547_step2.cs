using System.Data.Entity.Migrations;

namespace Pdc.System.Data.Test.Migrations
{
    public partial class step2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leads", "Processing", c => c.Int(nullable: false));
            DropColumn("dbo.Leads", "PDC_VERARB_FLAG");
        }

        public override void Down()
        {
            AddColumn("dbo.Leads", "PDC_VERARB_FLAG", c => c.Int(nullable: false));
            DropColumn("dbo.Leads", "Processing");
        }
    }
}