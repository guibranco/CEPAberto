// ***********************************************************************
// Assembly         : CEPAberto
// Author           : Guilherme Branco Stracini
// Created          : 2018-08-15
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 2018-08-15
// ***********************************************************************
// <copyright file="RequestExtensions.cs" company="Guilherme Branco Stracini">
//     Copyright © 2018 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CEPAberto.Utils
{
    using Attributes;
    using GoodPractices;
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Transport;

    /// <summary>
    /// The request extensions class.
    /// Provides extensions methods for requests attributes.
    /// </summary>
    public static class RequestExtensions
    {
        /// <summary>
        /// Gets the request end point attribute.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public static RequestEndPointAttribute GetRequestEndPointAttribute(this BaseRequest request)
        {
            if (!(request.GetType().GetCustomAttributes(typeof(RequestEndPointAttribute), false) is RequestEndPointAttribute[]
                      endpoints) ||
                !endpoints.Any())
                return null;
            return endpoints.Single();
        }

        /// <summary>
        /// Gets the request end point.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>String.</returns>
        /// <exception cref="RequestEndPointBadFormatException"></exception>
        /// <exception cref="InvalidRequestEndPointException"></exception>
        public static String GetRequestEndPoint(this BaseRequest request)
        {
            var type = request.GetType();
            var endpointAttribute = request.GetRequestEndPointAttribute();
            if (endpointAttribute == null)
                return type.Name.ToUpper();
            var originalEndpoint = endpointAttribute.EndPoint;
            var endpoint = originalEndpoint;
            var regex = new Regex(@"/?(?<pattern>{(?<propertyName>\w+?)})/?");
            if (!regex.IsMatch(endpoint))
                return endpoint;
            var used = 0;
            var skiped = 0;
            var counter = 0;
            foreach (Match match in regex.Matches(endpoint))
            {
                counter++;
                var propertyName = match.Groups["propertyName"].Value;
                var property = type.GetProperty(propertyName);
                if (property == null)
                    throw new RequestEndPointBadFormatException(originalEndpoint);
                var propertyType = property.PropertyType;
                var propertyValue = property.GetValue(request, null);
                if (propertyValue == null ||
                    propertyType == typeof(Int32) && Convert.ToInt32(propertyValue) == 0 ||
                    propertyType == typeof(Int64) && Convert.ToInt64(propertyValue) == 0 ||
                    propertyType == typeof(Decimal) && Convert.ToDecimal(propertyValue) == new Decimal(0) ||
                    propertyType == typeof(String) && String.IsNullOrEmpty(propertyValue.ToString()))
                {
                    var defaultValue = String.Empty;
                    endpoint = endpoint.Replace(match.Value, defaultValue);
                    if (skiped == 0 && defaultValue == String.Empty)
                        skiped = counter;
                    continue;
                }
                used = counter;
                var value = propertyValue.ToString();
                if (property.PropertyType.IsEnum)
                    value = value.ToLower();
                endpoint = endpoint.Replace(match.Groups["pattern"].Value, value);
            }
            if (skiped != 0 && skiped < used)
                throw new InvalidRequestEndPointException(originalEndpoint, endpoint);
            return endpoint.Trim('/');
        }
    }
}
