﻿// ***********************************************************************
// Assembly         : CEPAberto
// Author           : Guilherme Branco Stracini
// Created          : 2018-08-15
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-10-2023
// ***********************************************************************
// <copyright file="InvalidRequestEndPointException.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CEPAberto.GoodPractices
{

    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Throws when a invalid request end point pattern is found while resolving the request endpoint
    /// </summary>
    /// <seealso cref="System.Exception" />

    [Serializable]
    public class InvalidRequestEndPointException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidRequestEndPointException" /> class.
        /// </summary>
        /// <param name="endpointPattern">The endpoint pattern.</param>
        /// <param name="endpointResolved">The endpoint resolved.</param>
        public InvalidRequestEndPointException(string endpointPattern, string endpointResolved)
            : base($"The endpoint {endpointResolved} is not valid for the pattern {endpointPattern}")
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Exception" /> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info" /> parameter is <see langword="null" />.</exception>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is <see langword="null" /> or <see cref="P:System.Exception.HResult" /> is zero (0).</exception>
        public InvalidRequestEndPointException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}