// ***********************************************************************
// Assembly         : CEPAberto
// Author           : Guilherme Branco Stracini
// Created          : 2018-08-15
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 06-28-2020
// ***********************************************************************
// <copyright file="NearestRequest.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2020
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CEPAberto.Transport
{
    using Attributes;

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
        /// <value>The latitude.</value>
        public string Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>The longitude.</value>
        public string Longitude { get; set; }

    }
}
