﻿// ***********************************************************************
// Assembly         : CEPAberto
// Author           : Guilherme Branco Stracini
// Created          : 2018-08-15
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-10-2023
// ***********************************************************************
// <copyright file="CitiesData.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace CEPAberto.ValueObject
{
    using Newtonsoft.Json;

    /// <summary>
    /// The cities data response class.
    /// </summary>
    public sealed class CitiesData
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Cities" /> is success.
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        [JsonIgnore]
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the state initials.
        /// </summary>
        /// <value>The state initials.</value>
        [JsonIgnore]
        public string StateInitials { get; set; }

        /// <summary>
        /// Gets or sets the cities.
        /// </summary>
        /// <value>The cities.</value>
        public City[] Cities { get; set; }
    }
}
