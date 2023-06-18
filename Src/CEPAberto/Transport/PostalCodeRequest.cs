// ***********************************************************************
// Assembly         : CEPAberto
// Author           : Guilherme Branco Stracini
// Created          : 2018-08-15
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 25/03/2023
// ***********************************************************************
// <copyright file="PostalCodeRequest.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************

using GuiStracini.SDKBuilder.Routing;

namespace CEPAberto.Transport
{
    /// <summary>
    /// The postal code request class.
    /// </summary>
    [EndpointRoute("cep?cep={PostalCode}")]
    public sealed class PostalCodeRequest : CEPAbertoBaseRequest
    {
        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>The postal code.</value>
        public string PostalCode { get; set; }
    }
}
