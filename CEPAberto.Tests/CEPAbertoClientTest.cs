using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CEPAberto.Tests
{
    using System;
    using System.Linq;

    [TestClass]
    public class CEPAbertoClientTest
    {
        /// <summary>
        /// The token
        /// </summary>
        private const String Token = "97bd98aa2ab0bab41140a06a7f7742a4";

        /// <summary>
        /// The client
        /// </summary>
        private CEPAbertoClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object" /> class.
        /// </summary>
        /// <returns></returns>
        [TestInitialize]
        public void TestInitialize()
        {
            _client = new CEPAbertoClient(Token);
        }

        /// <summary>
        /// Tests the search cep.
        /// </summary>
        [TestMethod]
        public void TestSearchCep()
        {
            var result = _client.GetData("40010000");
            Assert.IsTrue(result.Success);
            Assert.AreEqual(7, result.Altitude);
            Assert.AreEqual("40010000", result.PostalCode);
            Assert.AreEqual("-12.967192", result.Latitude);
            Assert.AreEqual("-38.5101976", result.Longitude);
            Assert.AreEqual("Avenida da França", result.Street);
            Assert.AreEqual("Comércio", result.Neighborhood);
            Assert.IsTrue(result.City.AreaCode.HasValue);
            Assert.AreEqual(71, result.City.AreaCode);
            Assert.IsTrue(result.City.FiscalCode.HasValue);
            Assert.AreEqual(2927408, result.City.FiscalCode);
            Assert.AreEqual("Salvador", result.City.Name);
            Assert.AreEqual("BA", result.State.Initials);

        }

        /// <summary>
        /// Tests the search nearest.
        /// </summary>
        [TestMethod]
        public void TestSearchNearest()
        {
            var result = _client.GetData("-20.55", "-43.63");
            Assert.IsTrue(result.Success);
            Assert.AreEqual(1072.4, result.Altitude);
            Assert.AreEqual("36420000", result.PostalCode);
            Assert.AreEqual("-20.5236387", result.Latitude);
            Assert.AreEqual("-43.691412", result.Longitude);
            Assert.AreEqual("Ouro Branco", result.Street);
            Assert.IsTrue(String.IsNullOrWhiteSpace(result.Neighborhood));
            Assert.IsTrue(result.City.AreaCode.HasValue);
            Assert.AreEqual(31, result.City.AreaCode);
            Assert.IsTrue(result.City.FiscalCode.HasValue);
            Assert.AreEqual(3145901, result.City.FiscalCode);
            Assert.AreEqual("Ouro Branco", result.City.Name);
            Assert.AreEqual("MG", result.State.Initials);
        }

        /// <summary>
        /// Tests the search full adddress.
        /// </summary>
        [TestMethod]
        public void TestSearchFullAdddress()
        {
            var result = _client.GetData("SP", "Ubatuba", String.Empty, String.Empty);
            Assert.IsTrue(result.Success);
            Assert.AreEqual(4.8, result.Altitude);
            Assert.AreEqual("11680000", result.PostalCode);
            Assert.AreEqual("-23.4336578", result.Latitude);
            Assert.AreEqual("-45.0838481", result.Longitude);
            Assert.AreEqual("Ubatuba", result.Street);
            Assert.IsTrue(String.IsNullOrWhiteSpace(result.Neighborhood));
            Assert.IsTrue(result.City.AreaCode.HasValue);
            Assert.AreEqual(12, result.City.AreaCode);
            Assert.IsTrue(result.City.FiscalCode.HasValue);
            Assert.AreEqual(3555406, result.City.FiscalCode);
            Assert.AreEqual("Ubatuba", result.City.Name);
            Assert.AreEqual("SP", result.State.Initials);
        }


        /// <summary>
        /// Tests the search cities.
        /// </summary>
        [TestMethod]
        public void TestSearchCities()
        {
            var result = _client.GetCities("AM");
            Assert.IsTrue(result.Success);
            Assert.AreEqual("Agrovila São Sebastião do Caburi (Parintins)", result.Cities.First().Name);
        }
    }
}
