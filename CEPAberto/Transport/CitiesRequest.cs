// ***********************************************************************
// Assembly         : CEPAberto
// Author           : Guilherme Branco Stracini
// Created          : 2018-08-15
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 2018-08-15
// ***********************************************************************
// <copyright file="CitiesRequest.cs" company="Guilherme Branco Stracini">
//     Copyright © 2018 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CEPAberto.Transport
{
    using Attributes;

    /// <summary>
    /// The cities request class.
    /// </summary>
    /// <seealso cref="CEPAberto.Transport.BaseRequest" />
    [RequestEndPoint("cities?estado={StateInitials}")]
    public sealed class CitiesRequest : BaseRequest
    {
        /// <summary>
        /// Gets or sets the state initials.
        /// </summary>
        /// <value>
        /// The state initials.
        /// </value>
        public string StateInitials { get; set; }
    }
}
