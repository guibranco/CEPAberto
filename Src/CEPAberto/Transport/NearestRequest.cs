// ***********************************************************************
// Assembly         : CEPAberto
// Author           : Guilherme Branco Stracini
// Created          : 2018-08-15
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 25/03/2023
// ***********************************************************************
// <copyright file="NearestRequest.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************

using GuiStracini.SDKBuilder.Routing;

namespace CEPAberto.Transport
{
    /// <summary>
    /// The nearest request class.
    /// </summary>
    /// <seealso cref="CEPAberto.Transport.CEPAbertoBaseRequest" />
    [EndpointRoute("nearest?lat={Latitude}&lng={Longitude}")]
    public sealed class NearestRequest : CEPAbertoBaseRequest
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
