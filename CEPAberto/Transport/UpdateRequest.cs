// ***********************************************************************
// Assembly         : CEPAberto
// Author           : Guilherme Branco Stracini
// Created          : 06-28-2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 25/03/2023
// ***********************************************************************
// <copyright file="UpdateRequest.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace CEPAberto.Transport
{
    using GuiStracini.SDKBuilder.Routing;
    using Newtonsoft.Json;

    /// <summary>
    /// Class UpdateRequest. This class cannot be inherited.
    /// </summary>
    [EndpointRoute("update")]
    public sealed class UpdateRequest : CEPAbertoBaseRequest
    {
        /// <summary>
        /// Gets or sets the postal codes.
        /// </summary>
        /// <value>The postal codes.</value>
        [JsonProperty("ceps")]
        public string PostalCodes { get; set; }
    }
}
