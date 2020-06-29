// ***********************************************************************
// Assembly         : CEPAberto
// Author           : Guilherme Branco Stracini
// Created          : 06-28-2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 06-28-2020
// ***********************************************************************
// <copyright file="UpdateRequest.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2020
// </copyright>
// <summary></summary>
// ***********************************************************************

using CEPAberto.Attributes;
using Newtonsoft.Json;

namespace CEPAberto.Transport
{
    /// <summary>
    /// Class UpdateRequest. This class cannot be inherited.
    /// </summary>
    [RequestEndPoint("update")]
    public sealed class UpdateRequest : BaseRequest
    {
        /// <summary>
        /// Gets or sets the postal codes.
        /// </summary>
        /// <value>The postal codes.</value>
        [JsonProperty("ceps")]
        public string PostalCodes { get; set; }
    }
}
