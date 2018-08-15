// ***********************************************************************
// Assembly         : CEPAberto
// Author           : Guilherme Branco Stracini
// Created          : 2018-08-15
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 2018-08-15
// ***********************************************************************
// <copyright file="RequestEndPointBadFormatException.cs" company="Guilherme Branco Stracini">
//     Copyright © 2018 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CEPAberto.GoodPractices
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Throws when a request end point is in a bad format
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public class RequestEndPointBadFormatException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestEndPointBadFormatException"/> class.
        /// </summary>
        /// <param name="endpointFormat">The endpoint format.</param>
        public RequestEndPointBadFormatException(String endpointFormat)
            : base($"Unable to resolve the endpoint format {endpointFormat}")
        { }

        /// <summary>Initializes a new instance of the <see cref="T:System.Exception" /> class with serialized data.</summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown. </param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination. </param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info" /> parameter is <see langword="null" />. </exception>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is <see langword="null" /> or <see cref="P:System.Exception.HResult" /> is zero (0). </exception>
        public RequestEndPointBadFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}