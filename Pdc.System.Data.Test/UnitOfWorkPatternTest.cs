
using System.Linq;
using System.Net.Http;
using NUnit.Compatibility;
using NUnit.Framework;
using Pdc.System.Data.Test.Patterns;

namespace Pdc.System.Data.Test
{


    [TestFixture]
    public class UnitOfWorkPatternTest
    {


        [Test]
        public void TestUpdater()
        {
            var unit = new UnitOfWorkLeadsRequests(new TestContext());
            var lead = unit.Leads.SelectById(1);
            lead.Adresse = "Langstrasse";
            unit.Leads.Update(lead);
            unit.Save();
        }

        [Test]
        public void TestRepository()
        {
            var unit = new UnitOfWorkLeadsRequests(new TestContext());


            var leadId = "2-2";

            unit.Leads.Insert(new Lead { Adresse = "Strassenstrasse 3", LeadId = leadId });
            var body = "body";

            unit.Requests.Insert(new Request { Body = body, Headers = "application/json" });

            unit.Save();

            Assert.AreEqual(unit.Leads.Select().Last().LeadId, leadId);
            Assert.AreEqual(unit.Requests.Select().Last().Body, body);
        }
    }
}
