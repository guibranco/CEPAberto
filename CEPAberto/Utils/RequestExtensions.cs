﻿// ***********************************************************************
// Assembly         : CEPAberto
// Author           : Guilherme Branco Stracini
// Created          : 2018-08-15
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-10-2023
// ***********************************************************************
// <copyright file="RequestExtensions.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace CEPAberto.Utils
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    using System.Globalization;
    using CEPAberto.Attributes;
    using CEPAberto.GoodPractices;
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using CEPAberto.Transport;

    /// <summary>
    /// Class Extensions.
    /// </summary>
    public static class RequestHelpers
    {
        /// <summary>
        /// Gets the request end point attribute.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>RequestEndPointAttribute.</returns>
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
        /// <exception cref="CEPAberto.GoodPractices.RequestEndPointBadFormatException"></exception>
        /// <exception cref="CEPAberto.GoodPractices.InvalidRequestEndPointException"></exception>
        /// <exception cref="RequestEndPointBadFormatException"></exception>
        /// <exception cref="InvalidRequestEndPointException"></exception>
        public static string GetRequestEndPoint(this BaseRequest request)
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
            var skipped = 0;
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
                    propertyType == typeof(int) && Convert.ToInt32(propertyValue) == 0 ||
                    propertyType == typeof(long) && Convert.ToInt64(propertyValue) == 0 ||
                    propertyType == typeof(decimal) && Convert.ToDecimal(propertyValue) == new decimal(0) ||
                    propertyType == typeof(string) && string.IsNullOrEmpty(propertyValue.ToString()))
                {
                    var defaultValue = string.Empty;
                    endpoint = endpoint.Replace(match.Value, defaultValue);
                    if (skipped == 0 && defaultValue == string.Empty)
                        skipped = counter;
                    continue;
                }
                used = counter;
                endpoint = endpoint.Replace(match.Groups["pattern"].Value, propertyValue.ToString());
            }
            if (skipped != 0 && skipped < used)
                throw new InvalidRequestEndPointException(originalEndpoint, endpoint);
            return endpoint.Trim('/');
        }

        /// <summary>
        /// Gets the request additional parameter.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="requestMethod">The request method.</param>
        /// <returns>String.</returns>
        public static string GetRequestAdditionalParameter(this BaseRequest request, ActionMethod requestMethod)
        {
            var type = request.GetType();
            var properties = type.GetProperties().Where(prop => prop.IsDefined(typeof(RequestAdditionalParameterAttribute), false)).ToList();
            if (!properties.Any())
                return string.Empty;
            var builder = new StringBuilder();
            foreach (var property in properties)
            {
                if (!(property.GetCustomAttributes(typeof(RequestAdditionalParameterAttribute), false) is RequestAdditionalParameterAttribute[] attributes) || attributes.All(a => a.Type != requestMethod))
                    continue;
                var addAsQueryString = attributes.Single(a => a.Type == requestMethod).AsQueryString;
                var propertyValue = property.GetValue(request);
                if (propertyValue == null)
                    continue;

                if (property.PropertyType == typeof(bool))
                    propertyValue = propertyValue.ToString().ToLower();
                var propertyName = property.Name;
                if (property.GetCustomAttributes(typeof(JsonPropertyAttribute), false) is JsonPropertyAttribute[] attributesJson &&
                    attributesJson.Any())
                    propertyName = attributesJson.Single().PropertyName;
                if (property.PropertyType == typeof(string) && !string.IsNullOrWhiteSpace(propertyValue.ToString()) ||
                    property.PropertyType == typeof(bool) ||
                    property.PropertyType == typeof(int) && Convert.ToInt32(propertyValue) > 0 ||
                    property.PropertyType == typeof(long) && Convert.ToInt64(propertyValue) > 0)
                    builder.AppendFormat("{0}", addAsQueryString ? $"&{propertyName}=" : string.Empty).Append(propertyValue);
            }
            return builder.ToString();
        }

        /// <summary>
        /// Converts to key value.
        /// </summary>
        /// <param name="metaToken">The meta token.</param>
        /// <returns>IDictionary&lt;System.String, System.String&gt;.</returns>
        public static IDictionary<string, string> ToKeyValue(this object metaToken)
        {
            while (true)
            {
                if (metaToken == null)
                {
                    return null;
                }

                var token = metaToken as JToken;
                if (token == null)
                {
                    metaToken = JObject.FromObject(metaToken);
                    continue;
                }

                if (token.HasValues)
                {
                    var contentData = new Dictionary<string, string>();
                    foreach (var child in token.Children().ToList())
                    {
                        var childContent = child.ToKeyValue();
                        if (childContent != null)
                        {
                            contentData = contentData.Concat(childContent)
                                .ToDictionary(k => k.Key, v => v.Value);
                        }
                    }

                    return contentData;
                }

                var jValue = token as JValue;
                if (jValue?.Value == null)
                {
                    return null;
                }

                var value = jValue.Type == JTokenType.Date ? jValue.ToString("o", CultureInfo.InvariantCulture) : jValue.ToString(CultureInfo.InvariantCulture);

                return new Dictionary<string, string> { { token.Path, value } };
            }
        }
    }
}