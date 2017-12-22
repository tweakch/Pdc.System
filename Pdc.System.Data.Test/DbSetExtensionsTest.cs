using NUnit.Framework;
using Pdc.System.Data.Extensions;
using System.Linq;

namespace Pdc.System.Data.Test
{
    [TestFixture]
    public class DbSetExtensionsTest
    {
        [Test]
        public void TestDataTableCreation()
        {
            //Arrange
            var context = new TestContext();
            var rows = context.Leads.ToList().Count;
            var columns = typeof(Lead).GetProperties().Count();
            context.Leads.Add(new Lead { Adresse = "Strassenstrasse 1", LeadId = "1" });
            context.SaveChanges();

            //Act
            var dataTable = context.Leads.ToDataTable();

            //Assert
            Assert.AreEqual(rows + 1, dataTable.Rows.Count);
            Assert.AreEqual(columns, dataTable.Columns.Count);
        }
    }
}