using System.Data.Entity.Migrations;
using System.IO;

namespace Pdc.System.Data.Test.Migrations
{
    using Pdc.Serialization.Json;

    internal sealed class Configuration : DbMigrationsConfiguration<TestContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TestContext context)
        {
            var leadSeed = @"C:\Workspaces\TeamProject.PdcFramework\Pdc.System.Data.Test\leads.seed.json";
            var leads = File.ReadAllText(leadSeed).ToList<Lead>().ToArray();
            context.Leads.AddOrUpdate(l => l.Id, leads);

            var reqSeed = @"C:\Workspaces\TeamProject.PdcFramework\Pdc.System.Data.Test\requests.seed.json";
            var requests = File.ReadAllText(reqSeed).ToList<Request>().ToArray();
            context.Requests.AddOrUpdate(l => l.Id, requests);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}