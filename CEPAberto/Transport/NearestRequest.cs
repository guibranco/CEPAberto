// ***********************************************************************
// Assembly         : CEPAberto
// Author           : Guilherme Branco Stracini
// Created          : 2018-08-15
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 2018-08-15
// ***********************************************************************
// <copyright file="NearestRequest.cs" company="Guilherme Branco Stracini">
//     Copyright © 2018 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CEPAberto.Transport
{
    using Attributes;
    using System;

    /// <summary>
    /// The nearest request class.
    /// </summary>
    /// <seealso cref="CEPAberto.Transport.BaseRequest" />
    [RequestEndPoint("nearest?lat={Latitude}&lng={Longitude}")]
    public sealed class NearestRequest : BaseRequest
    {
        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>
        /// The latitude.
        /// </value>
        public String Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        public String Longitude { get; set; }

    }
}
