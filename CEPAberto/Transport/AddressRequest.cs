// ***********************************************************************
// Assembly         : CEPAberto
// Author           : Guilherme Branco Stracini
// Created          : 2018-08-15
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 2018-08-16
// ***********************************************************************
// <copyright file="AddressRequest.cs" company="Guilherme Branco Stracini">
//     Copyright © 2018 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CEPAberto.Transport
{
    using Attributes;
    using Newtonsoft.Json;
    using System;
    using Utils;

    /// <summary>
    /// The address request class.
    /// </summary>
    /// <seealso cref="CEPAberto.Transport.BaseRequest" />
    [RequestEndPoint("address?estado={StateInitials}&cidade={City}")]
    public sealed class AddressRequest : BaseRequest
    {
        /// <summary>
        /// Gets or sets the state initials.
        /// </summary>
        /// <value>
        /// The state initials.
        /// </value>
        public String StateInitials { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public String City { get; set; }

        /// <summary>
        /// Gets or sets the neighborhood.
        /// </summary>
        /// <value>
        /// The neighborhood.
        /// </value>
        [RequestAdditionalParameter(ActionMethod.GET, true)]
        [JsonProperty("bairro")]
        public String Neighborhood { get; set; }

        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        /// <value>
        /// The street.
        /// </value>
        [RequestAdditionalParameter(ActionMethod.GET, true)]
        [JsonProperty("logradouro")]
        public String Street { get; set; }
    }
}
