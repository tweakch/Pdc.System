using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Pdc.Serialization.Json;

namespace Pdc.Notation.Test
{

    [TestFixture]
    public class JsonExtensionsTest
    {
        interface IContract
        {
            [JsonProperty("name")]
            string MyName { get; set; }

            [JsonProperty("number")]
            int MyNumber { get; set; }

            [JsonProperty("id")]
            Guid MyId { get; set; }

            [JsonProperty("dateTime")]
            DateTime MyDateTime { get; set; }
        }

        class WithInterfaceContract : IContract
        {
            public string MyName { get; set; }
            public int MyNumber { get; set; }
            public Guid MyId { get; set; }
            public DateTime MyDateTime { get; set; }
        }

        class WithInlineContract
        {
            [JsonProperty("name")]
            public string TheName { get; set; }

            [JsonProperty("number")]
            public int TheValue { get; set; }

            [JsonProperty("id")]
            public Guid TheId { get; set; }

            [JsonProperty("dateTime")]
            public DateTime TheDateTime { get; set; }
        }

        class NoContract
        {
            public string Name { get; set; }
            public int Number { get; set; }
            public Guid Id { get; set; }
            public DateTime CurrentDate { get; set; }
        }

        [Test]
        public void NoContractToJsonString()
        {
            //Arrange
            var test = new NoContract
            {
                Id = Guid.Empty,
                Name = "Test Name",
                Number = -1,
                CurrentDate = DateTime.Now //("2017-12-15T00:00:00+01:00")
            };

            var expectedJson = $"{{\"name\":\"{test.Name}\",\"number\":{test.Number},\"id\":\"{test.Id}\",\"currentDate\":\"{test.CurrentDate.ToString("O")}\"}}";
            
            var instance = JsonExtensions.ToInstance<NoContract>(expectedJson);
            //Act 
            var json = test.ToJson();

            //Assert
            Assert.AreEqual(expectedJson, json);
        }
        [Test]
        public void InlineContractToJsonString()
        {
            //Arrange
            var test = new WithInlineContract
            {
                TheId = Guid.Empty,
                TheName = "Test Name",
                TheValue = -1,
                TheDateTime = DateTime.Now
            };

            var expectedJson = $"{{\"name\":\"{test.TheName}\",\"number\":{test.TheValue},\"id\":\"{test.TheId}\",\"dateTime\":\"{test.TheDateTime.ToString("O")}\"}}";


            //Act 
            var json = test.ToJson();

            //Assert
            Assert.AreEqual(expectedJson, json);
        }
        [Test]
        public void InterfaceContractToJsonString()
        {
            var propName = "name";
            var propNumber = "number";
            var propDateTime = "dateTime";
            var propId = "id";

            //Arrange
            var test = new WithInterfaceContract()
            {
                MyName = "SomeName",
                MyNumber = 2,
                MyDateTime = DateTime.Now,
                MyId = Guid.NewGuid()
            };
            
            var expectedJson = $"{{\"{propName}\":\"{test.MyName}\",\"{propNumber}\":{test.MyNumber},\"{propId}\":\"{test.MyId}\",\"{propDateTime}\":\"{test.MyDateTime.ToString("O")}\"}}";

            //Act 
            var json = test.ToJson();

            //Assert
            Assert.AreEqual(expectedJson, json);
        }

        [Test]
        public void NoContractFromJsonString()
        {
            //Arrange
            var json = "{\"Name\":\"Test Name\",\"Number\":-1,\"Id\":\"00000000-0000-0000-0000-000000000000\"}";

            //Act
            var test = JsonExtensions.ToInstance<NoContract>(json);

            //Assert
            Assert.AreEqual(-1, test.Number);
            Assert.AreEqual("Test Name", test.Name);
            Assert.AreEqual(Guid.Empty, test.Id);
        }

        [Test]
        public void MapJson()
        {
            //Arrange
            var nameTest = "Name Test";
            var numbTest = "-4";
            var guidTest = "12345678-9101-1121-3141-151617181920";
            var json = $"{{\"Name\":\"{nameTest}\",\"Number\":{numbTest},\"Id\":\"{guidTest}\"}}";
            var test = new NoContract();

            //Act
            test.FromJson(json);

            //Assert
            Assert.AreEqual(Convert.ToInt32(numbTest), test.Number);
            Assert.AreEqual(nameTest, test.Name);
            Assert.AreEqual(Guid.Parse(guidTest), test.Id);
        }

        [Test]
        public void OverPosting()
        {
            //Arrange
            var nameTest = "Name Test";
            var numbTest = "-4";
            var guidTest = "12345678-9101-1121-3141-151617181920";
            var json = $"{{\"Name\":\"{nameTest}\",\"Number\":{numbTest},\"Id\":\"{guidTest}\",\"OverpostedProperty\":\"something\"}}";

            //Act
            var test = JsonExtensions.ToInstance<NoContract>(json);

            //Assert
            Assert.AreEqual(Convert.ToInt32(numbTest), test.Number);
            Assert.AreEqual(nameTest, test.Name);
            Assert.AreEqual(Guid.Parse(guidTest), test.Id);
        }

        [Test]
        public void UnderPosting()
        {
            //Arrange
            var nameTest = "Name Test";
            var json = $"{{\"Name\":\"{nameTest}\"}}";

            //Act
            var noContract = JsonExtensions.ToInstance<NoContract>(json);

            //Assert
            Assert.AreEqual(nameTest, noContract.Name);
            Assert.AreEqual(0, noContract.Number);
            Assert.AreEqual(Guid.Empty, noContract.Id);
        }

        [Test]
        public void JObjectToInlineContractSerialization()
        {
            //Arrange
            var id = Guid.NewGuid();
            var dateTime = DateTime.Now;
            var name = "the name of the object";
            var number = 3;

            var jObject1 = new JObject()
            {
                {nameof(id), id},
                {nameof(name), name},
                {nameof(number), number},
                {nameof(dateTime), dateTime}
            };
            var jObject = jObject1;

            //Act
            var test = jObject.ToObject<WithInlineContract>();
            
            //Assert
            Assert.AreEqual(name, test.TheName);
            Assert.AreEqual(number, test.TheValue);
            Assert.AreEqual(id, test.TheId);
            Assert.AreEqual(dateTime, test.TheDateTime);
        }

        [Test]
        public void JObjectToInterfaceContractSerialization()
        {
            //Arrange
            var id = Guid.NewGuid();
            var dateTime = DateTime.Now;
            var name = "the name of the object";
            var number = 3;

            var jObject = new JObject
            {
                {nameof(id), id},
                {nameof(name), name},
                {nameof(number), number},
                {nameof(dateTime), dateTime}
            };

            //Act
            var testClass = jObject.ToObject<WithInterfaceContract>();

            //Assert
            Assert.AreEqual(name, testClass.MyName);
            Assert.AreEqual(number, testClass.MyNumber);
            Assert.AreEqual(id, testClass.MyId);
            Assert.AreEqual(dateTime, testClass.MyDateTime);
        }
    }
}
