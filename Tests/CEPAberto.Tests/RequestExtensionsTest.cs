// ***********************************************************************
// Assembly         : CEPAberto.Tests
// Author           : Guilherme Branco Stracini
// Created          : 16-08-2018
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 25/03/2023
// ***********************************************************************
// <copyright file="RequestExtensionsTest.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************

using GuiStracini.SDKBuilder;

namespace CEPAberto.Tests
{
    using System.Collections.Generic;

    using Utils;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Transport;

    /// <summary>
    /// Defines test class RequestHelpersTest.
    /// </summary>
    [TestClass]
    public class RequestHelpersTest
    {
        /// <summary>
        /// Defines the test method RequestEndPoint.
        /// </summary>
        [TestMethod]
        public void RequestEndPoint()
        {
            const string expected = "cep?cep=12345678";
            var postalCode = new PostalCodeRequest
            {
                PostalCode = "12345678"
            };
            var result = postalCode.GetRequestEndPoint();
            Assert.AreEqual(expected, result, "The endpoint was not resolves as expected");
        }

        /// <summary>
        /// Defines the test method RequestEndPointWithMultipleParameters.
        /// </summary>
        [TestMethod]
        public void RequestEndPointWithMultipleParameters()
        {
            const string expected = "nearest?lat=10&lng=-20";
            var nearest = new NearestRequest
            {
                Latitude = "10",
                Longitude = "-20"
            };
            var result = nearest.GetRequestEndPoint();
            Assert.AreEqual(expected, result, "The endpoint was not resolves as expected");
        }

        /// <summary>
        /// Defines the test method RequestEndPointWithNullValues.
        /// </summary>
        [TestMethod]
        public void RequestEndPointWithNullValues()
        {
            var address = new AddressRequest
            {
                StateInitials = "SP",
                City = "São Paulo"
            };
            var result = address.GetRequestAdditionalParameter(ActionMethod.GET);
            Assert.AreEqual(string.Empty, result, "The endpoint was not resolves as expected");
        }

        /// <summary>
        /// Defines the test method RequestAdditionalParameterAsQueryString.
        /// </summary>
        [TestMethod]
        public void RequestAdditionalParameterAsQueryString()
        {
            const string expected = "&bairro=Centro&logradouro=Se";
            var address = new AddressRequest
            {
                StateInitials = "SP",
                City = "São Paulo",
                Neighborhood = "Centro",
                Street = "Se"
            };
            var result = address.GetRequestAdditionalParameter(ActionMethod.GET).Replace("/?", "&");
            Assert.AreEqual(expected, result, "The additional parameter should be query string");
        }

        [TestMethod]
        public void ValidateToKeyValue_MetaTokenIsNull_ReturnsEmptyDictionary()
        {
            var result = ((object)null).ToKeyValue();

            Assert.IsInstanceOfType<Dictionary<string, string>>(result);
            Assert.AreEqual(0, result.Count);
        }
    }
}