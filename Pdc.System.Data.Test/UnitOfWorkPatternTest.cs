using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Pdc.System.Data.Test.Patterns;

namespace Pdc.System.Data.Test
{
    [TestFixture]
    public class UnitOfWorkPatternTest
    {
        [Test]
        public void TestRepository()
        {
            var unit = new UnitOfWorkLeadsRequests(new TestContext());
            unit.Leads.Insert(new Lead {Adresse = "Strassenstrasse 1", LeadId = "1"});
            unit.Requests.Insert(new Request {Body = "body", Headers = "application/json"});
            unit.Save();
        }
    }
}
