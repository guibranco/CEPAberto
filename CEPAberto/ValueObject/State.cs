// ***********************************************************************
// Assembly         : CEPAberto
// Author           : Guilherme Branco Stracini
// Created          : 2018-08-15
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-10-2023
// ***********************************************************************
// <copyright file="State.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace CEPAberto.ValueObject
{
    using Newtonsoft.Json;

    /// <summary>
    /// The state entity of the postal code response.
    /// </summary>
    public sealed class State
    {
        /// <summary>
        /// Gets or sets the initials.
        /// </summary>
        /// <value>The initials.</value>
        [JsonProperty("sigla")]
        public string Initials { get; set; }
    }
}
