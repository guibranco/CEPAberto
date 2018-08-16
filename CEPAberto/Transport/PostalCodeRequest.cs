// ***********************************************************************
// Assembly         : CEPAberto
// Author           : Guilherme Branco Stracini
// Created          : 2018-08-15
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 2018-08-15
// ***********************************************************************
// <copyright file="PostalCodeRequest.cs" company="Guilherme Branco Stracini">
//     Copyright © 2018 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CEPAberto.Transport
{
    using Attributes;
    using System;

    /// <summary>
    /// The postal code request class.
    /// </summary>
    [RequestEndPoint("cep?cep={PostalCode}")]
    public sealed class PostalCodeRequest : BaseRequest
    {
        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>
        /// The postal code.
        /// </value>
        public String PostalCode { get; set; }
    }
}
