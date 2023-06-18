// ***********************************************************************
// Assembly         : CEPAberto.Tests
// Author           : Guilherme Branco Stracini
// Created          : 15-08-2018
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 25/03/2023
// ***********************************************************************
// <copyright file="CEPAbertoClientTest.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CEPAberto.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// Defines test class CEPAbertoClientTest.
    /// </summary>
    [TestClass]
    public class CEPAbertoClientTest
    {
        /// <summary>
        /// The token
        /// </summary>
        private const string _token = "97bd98aa2ab0bab41140a06a7f7742a4";

        /// <summary>
        /// The client
        /// </summary>
        private CEPAbertoClient _client;

        /// <summary>
        /// Tests the initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            _client = new CEPAbertoClient(_token);
            Thread.Sleep(1000);
        }

        /// <summary>
        /// Defines the test method TestSearchCep.
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
        /// Defines the test method TestSearchNearest.
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
            Assert.IsNull(result.Neighborhood);
            Assert.IsNull(result.Street);
            Assert.IsTrue(result.City.AreaCode.HasValue);
            Assert.AreEqual(31, result.City.AreaCode);
            Assert.IsTrue(result.City.FiscalCode.HasValue);
            Assert.AreEqual(3145901, result.City.FiscalCode);
            Assert.AreEqual("Ouro Branco", result.City.Name);
            Assert.AreEqual("MG", result.State.Initials);
        }

        /// <summary>
        /// Defines the test method TestSearchFullAddress.
        /// </summary>
        [TestMethod]
        public void TestSearchFullAddress()
        {
            var result = _client.GetData("SP", "Ubatuba", string.Empty, string.Empty);

            Assert.IsTrue(result.Success);

            Assert.AreEqual(4.8, result.Altitude);
            Assert.AreEqual("11680000", result.PostalCode);
            Assert.AreEqual("-23.4336578", result.Latitude);
            Assert.AreEqual("-45.0838481", result.Longitude);
            Assert.IsNull(result.Street);
            Assert.IsNull(result.Neighborhood);
            Assert.IsTrue(result.City.AreaCode.HasValue);
            Assert.AreEqual(12, result.City.AreaCode);
            Assert.IsTrue(result.City.FiscalCode.HasValue);
            Assert.AreEqual(3555406, result.City.FiscalCode);
            Assert.AreEqual("Ubatuba", result.City.Name);
            Assert.AreEqual("SP", result.State.Initials);
        }

        /// <summary>
        /// Defines the test method TestSearchCities.
        /// </summary>
        [TestMethod]
        public void TestSearchCities()
        {
            var result = _client.GetCities("AM");

            Assert.IsTrue(result.Success);

            Assert.AreEqual(
                "Agrovila São Sebastião do Caburi (Parintins)",
                result.Cities.First().Name
            );
        }

        /// <summary>
        /// Defines the test method TestUpdate.
        /// </summary>
        [TestMethod]
        public void TestUpdate()
        {
            var postalCodeList = new[] { "03177010", "36420000" };

            var result = _client.Update(postalCodeList);

            Assert.IsTrue(result.Success);
        }

        /// <summary>
        /// Defines the test method TestUpdateWrongData.
        /// </summary>
        [TestMethod]
        public void TestUpdateWrongData()
        {
            var postalCodeLIst = new[] { "03177010", "0012" };

            var result = _client.Update(postalCodeLIst);

            Assert.IsFalse(result.Success);
        }
    }
}
