// ***********************************************************************
// Assembly         : CEPAberto
// Author           : Guilherme Branco Stracini
// Created          : 2018-08-15
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 2018-08-15
// ***********************************************************************
// <copyright file="City.cs" company="Guilherme Branco Stracini">
//     Copyright © 2018 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

using Newtonsoft.Json;

namespace CEPAberto.ValueObject
{
    /// <summary>
    /// The city enttiy of  the postal code response
    /// </summary>
    public sealed class City
    {

        /// <summary>
        /// Gets or sets the area code.
        /// </summary>
        /// <value>
        /// The area code.
        /// </value>
        [JsonProperty("ddd")]
        public int? AreaCode { get; set; }

        /// <summary>
        /// Gets or sets the fiscal code.
        /// </summary>
        /// <value>
        /// The fiscal code.
        /// </value>
        [JsonProperty("ibge")]
        public int? FiscalCode { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonProperty("nome")]
        public string Name { get; set; }
    }
}
