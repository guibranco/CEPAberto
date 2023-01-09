// ***********************************************************************
// Assembly         : CEPAberto
// Author           : Guilherme Branco Stracini
// Created          : 2018-08-15
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-10-2023
// ***********************************************************************
// <copyright file="AddressRequest.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace CEPAberto.Transport
{
    using Newtonsoft.Json;
    using CEPAberto.Attributes;
    using CEPAberto.Utils;

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
        /// <value>The state initials.</value>
        public string StateInitials { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the neighborhood.
        /// </summary>
        /// <value>The neighborhood.</value>
        [RequestAdditionalParameter(ActionMethod.Get, true)]
        [JsonProperty("bairro")]
        public string Neighborhood { get; set; }

        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        /// <value>The street.</value>
        [RequestAdditionalParameter(ActionMethod.Get, true)]
        [JsonProperty("logradouro")]
        public string Street { get; set; }
    }
}
