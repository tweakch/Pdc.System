using System.Data.Entity.Migrations;

namespace Pdc.System.Data.Test.Migrations
{
    public partial class step0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Leads",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    PDC_VERARB_FLAG = c.Int(nullable: false),
                    LeadId = c.String(),
                    Adresse = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Requests",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    PDC_VERARB_FLAG = c.Int(nullable: false),
                    Headers = c.String(),
                    Body = c.String(),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Requests");
            DropTable("dbo.Leads");
        }
    }
}