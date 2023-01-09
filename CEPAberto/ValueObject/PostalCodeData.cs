// ***********************************************************************
// Assembly         : CEPAberto
// Author           : Guilherme Branco Stracini
// Created          : 2018-08-15
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-10-2023
// ***********************************************************************
// <copyright file="PostalCodeData.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace CEPAberto.ValueObject
{
    using Newtonsoft.Json;

    /// <summary>
    /// The postal code data class.
    /// This class contains the response of a request to the API
    /// </summary>
    public sealed class PostalCodeData
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PostalCodeData" /> is success.
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        [JsonIgnore]
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the altitude.
        /// </summary>
        /// <value>The altitude.</value>
        [JsonProperty("altitude")]
        public double? Altitude { get; set; }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>The postal code.</value>
        [JsonProperty("cep")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>The latitude.</value>
        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>The longitude.</value>
        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        /// <value>The street.</value>
        [JsonProperty("logradouro")]
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the neighborhood.
        /// </summary>
        /// <value>The neighborhood.</value>
        [JsonProperty("bairro")]
        public string Neighborhood { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        [JsonProperty("cidade")]
        public City City { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        [JsonProperty("estado")]
        public State State { get; set; }
    }
}
