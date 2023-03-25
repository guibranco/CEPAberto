// ***********************************************************************
// Assembly         : CEPAberto
// Author           : Guilherme Branco Stracini
// Created          : 2018-08-15
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 25/03/2023
// ***********************************************************************
// <copyright file="CitiesRequest.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CEPAberto.Transport
{
    using GuiStracini.SDKBuilder.Routing;

    /// <summary>
    /// The cities request class.
    /// </summary>
    /// <seealso cref="CEPAberto.Transport.CEPAbertoBaseRequest" />
    [EndpointRoute("cities?estado={StateInitials}")]
    public sealed class CitiesRequest : CEPAbertoBaseRequest
    {
        /// <summary>
        /// Gets or sets the state initials.
        /// </summary>
        /// <value>The state initials.</value>
        public string StateInitials { get; set; }
    }
}
