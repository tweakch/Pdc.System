using NUnit.Framework;
using Pdc.System.Component.Connector;
using Pdc.System.Sample.Components.Active;
using Pdc.System.Sample.Components.Passive;
using System.Collections.Generic;
using System.Linq;

namespace Pdc.System.Sample.Test
{
    [TestFixture]
    public class SampleTest
    {
        [Test]
        public void TestStaticHelper()
        {
            // Arrange
            const string iata = "JFK";

            // Act
            var info = AirportInfoComponent.Execute(iata);

            // Assert
            Assert.NotNull(info);
            Assert.IsInstanceOf(typeof(string), info);
        }

        [Test]
        public void TestGenericExecuteHelper()
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
        public void TestInstanceExecute()
        {
            var component = new AirportInfoComponent();
            var channelName = component.Channels.First().Name;
            var results = component.Execute(channelName, "JFK", "LAX", "ORD", "MIA");
            Assert.IsInstanceOf<List<object>>(results);
        }

        [Test]
        public void TestInstanceConnectorExecute()
        {
            var component = new AirportInfoComponent();
            var channelName = component.Channels.First().Name;
            var results = component.Execute(channelName, "JFK", "LAX", "ORD");
            Assert.IsInstanceOf<List<object>>(results);
        }

        [Test]
        public void TestMethod3()
        {
            // Arrange
            var sequence = PipeConnector.CreateSequence<AirportInfoComponent, UnaryAbbreviationExtenderComponent>();

            // Act
            var example = sequence.Execute("JFK");

            // Assert
            Assert.True(example.ToString().Contains("John Fitzgerald Kennedy"));
        }

        [Test]
        public void TestMethod4()
        {
            // Arrange
            var sequence = PipeConnector.CreateSequence<AirportInfoComponent, UnaryAbbreviationExtenderComponent>();
            var inverse = PipeConnector.CreateSequence<UnaryAbbreviationExtenderComponent, AirportInfoComponent>();

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
            const string iata = "JFK";
            string result, frameworkResult;

            // We test the functionality of a component like this.
            UnaryAbbreviationExtenderComponent.Execute(iata, out result);

            // Components invoke each other like this
            var component = new UnaryAbbreviationExtenderComponent();
            var connector = (UnaryComputationConnector<string>)component.Connector;
            connector.Execute(iata, out frameworkResult);

            //
            Assert.AreEqual("John Fitzgerald Kennedy", result);
            Assert.AreEqual(result, frameworkResult);
        }
    }
}