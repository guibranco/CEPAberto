// ***********************************************************************
// Assembly         : CEPAberto
// Author           : Guilherme Branco Stracini
// Created          : 2018-08-15
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-10-2023
// ***********************************************************************
// <copyright file="RequestEndPointAttribute.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CEPAberto.Attributes
{
    using System;

    /// <summary>
    /// Class RequestEndPointAttribute. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class RequestEndPointAttribute : Attribute
    {

        #region ~Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestEndPointAttribute" /> class.
        /// </summary>
        /// <param name="endPoint">The end point path of the request.</param>
        public RequestEndPointAttribute(string endPoint)
        {
            EndPoint = endPoint;
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the end point.
        /// </summary>
        /// <value>The end point path.</value>
        public string EndPoint { get; }

        #endregion

    }
}