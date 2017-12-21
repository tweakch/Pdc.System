using System.Collections.Generic;
using NUnit.Framework;
using Pdc.System.Component.Connector;
using Pdc.System.Sample.Components.Active;
using Pdc.System.Sample.Components.Passive;

namespace Pdc.System.Sample.Test
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            // Arrange
            const string iata = "JFK";

            // Act
            var info = AirportInfoComponent.Execute(iata);

            // Assert
            Assert.NotNull(info);
        }

        [Test]
        public void TestMethod2()
        {
            // Arrange
            const string iata = "LAX";

            // Act
            var airportInfo = AirportInfoComponent.Execute<AirportInfo>(iata);
            var state = airportInfo.State;

            // Assert
            Assert.AreEqual("California", state);
        }

        [Test]
        public void TestMethod3()
        {
            // Arrange
            var sequence = PipeConnector.Sequence<AirportInfoComponent, UnaryAbbreviationExtenderComponent>();

            // Act
            var example = sequence.Execute("JFK");

            // Assert
            Assert.True(example.ToString().Contains("John Fitzgerald Kennedy"));
        }

        [Test]
        public void TestMethod4()
        {
            // Arrange
            var sequence = PipeConnector.Sequence<AirportInfoComponent, UnaryAbbreviationExtenderComponent>();
            var inverse = PipeConnector.Sequence<UnaryAbbreviationExtenderComponent, AirportInfoComponent>();

            // Act
            var example = sequence.Execute("JFK") as List<object>;
            var inverseExample = inverse.Execute("JFK") as List<object>;

            // Assert
            Assert.NotNull(example);
            Assert.NotNull(inverseExample);

            Assert.True(example[0].ToString().Contains("John Fitzgerald Kennedy"));
            Assert.AreEqual("The computation finished with an error.", inverseExample[0]);
        }

        [Test]
        public void TestMethod5()
        {
            // Arrange
            const string iata = "JFK";
            string result, frameworkResult;

            // Act: we test the functionality of the component like this.
            UnaryAbbreviationExtenderComponent.Execute(iata, out result);

            // The Pdc.System.Component Framework invokes the component like this.
            var component = new UnaryAbbreviationExtenderComponent();
            var connector = (UnaryComputationConnector<string>) component.Connector;
            connector.Execute(iata, out frameworkResult);

            // Assert
            Assert.AreEqual("John Fitzgerald Kennedy", result);
            Assert.AreEqual(result, frameworkResult);
        }
    }
}