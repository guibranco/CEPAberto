// ***********************************************************************
// Assembly         : CEPAberto
// Author           : Guilherme Branco Stracini
// Created          : 2018-08-16
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 2018-08-16
// ***********************************************************************
// <copyright file="RequestAdditionalParameter.cs" company="Guilherme Branco Stracini">
//     Copyright © 2018 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CEPAberto.Attributes
{
    using System;
    using Utils;

    /// <summary>
    /// Use this attribute to include the value os the property in the request endpoint for specific action method.
    /// E.g. A GET/PUT request should include the field "Name" of a entity in the URL, so add this attribute to the Name property in the transport class, and set the ActionMethod to GET and PUT (2 attributes)
    /// </summary>
    /// <example>
    /// Using a generic transport class, inherited from <see cref="CEPAberto.Transport.BaseRequest"/>
    /// <code>
    /// [RequestEndPoint("/Sample/{id}")] //The id property is used in all requests if it's populated
    /// public class SampleTransport : BaseRequest 
    /// {
    ///     public Int32 Id { get; set; }
    /// 
    ///     [RequestAdditionalParameterAttribute(ActionMethod.GET)]
    ///     [RequestAdditionalParameterAttribute(ActionMethod.PUT)]
    ///     public String Name { get; set; } //The property Name is included in the url as querystring only in GET or PUT requests.
    /// }
    /// 
    /// var sample = new SampleTransport { Id = 1, Name = "Sample" };
    /// var endPointResult = sample.GetRequestEndPoint();
    /// Assert.AreEqual("/Sample/1/Sample", endpointResult);
    /// </code>
    /// 
    /// If the name of the property and its value should be added as query string to the url, so set the second constructor parameter to <c>true</c>
    /// <code>
    /// [RequestEndPoint("/Sample/{id}")] //The id property is used in all requests if it's populated
    /// public class SampleTransport :BaseRequest 
    /// {
    ///     public Int32 Id { get; set; }
    /// 
    ///     [RequestAdditionalParameterAttribute(ActionMethod.GET, true)]
    ///     [RequestAdditionalParameterAttribute(ActionMethod.PUT, true)]
    ///     public String Name { get; set; } //The property Name is included in the url as querystring only in GET or PUT requests.
    /// }
    /// 
    /// var sample = new SampleTransport { Id = 1, Name = "Sample" };
    /// var endPointResult = sample.GetRequestEndPoint();
    /// Assert.AreEqual("/Sample/1?Name=Sample", endpointResult);
    /// </code>
    /// 
    /// </example>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    internal sealed class RequestAdditionalParameterAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The action type of t he request.</value>
        public ActionMethod Type { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether the additional parameter should be added as query string to the url.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [as query string]; otherwise, <c>false</c>.
        /// </value>
        public bool AsQueryString { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestAdditionalParameterAttribute" /> class.
        /// </summary>
        /// <param name="type">The type of request.</param>
        /// <param name="asQueryString">if set to <c>true</c> the additional parameter is added in the url as query string.</param>
        public RequestAdditionalParameterAttribute(ActionMethod type, bool asQueryString = false)
        {
            AsQueryString = asQueryString;
            Type = type;
        }
    }
}