// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 2018-08-16
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 2018-08-16
// ***********************************************************************
// <copyright file="RequestExtensionsTests" company="Guilherme Branco Stracini">
//     Copyright © 2018 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CEPAberto.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Transport;
    using Utils;

    /// <summary>
    /// The request helpers test class
    /// </summary>
    [TestClass]
    public class RequestHelpersTest
    {
        /// <summary>
        /// Validates the request end point.
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
        /// Validates the request end point with multiple parameters.
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
        /// Validates the request end point with null values.
        /// </summary>
        [TestMethod]
        public void RequestEndPointWithNullValues()
        {
            var address = new AddressRequest
            {
                StateInitials = "SP",
                City = "São Paulo"
            };
            var result = address.GetRequestAdditionalParameter(ActionMethod.Get);
            Assert.AreEqual(string.Empty, result, "The endpoint was not resolves as expected");
        }


        /// <summary>
        /// Validates the request additional parameter as query string.
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
            var result = address.GetRequestAdditionalParameter(ActionMethod.Get);
            Assert.AreEqual(expected, result, "The additional parameter should be query string");
        }
    }
}