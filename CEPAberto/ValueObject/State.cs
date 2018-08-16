// ***********************************************************************
// Assembly         : CEPAberto
// Author           : Guilherme Branco Stracini
// Created          : 2018-08-15
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 2018-08-15
// ***********************************************************************
// <copyright file="State.cs" company="Guilherme Branco Stracini">
//     Copyright © 2018 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CEPAberto.ValueObject
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// The state entity of the postal code response.
    /// </summary>
    public sealed class State
    {
        /// <summary>
        /// Gets or sets the initials.
        /// </summary>
        /// <value>
        /// The initials.
        /// </value>
        [JsonProperty("sigla")]
        public String Initials { get; set; }
    }
}
