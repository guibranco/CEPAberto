﻿// ***********************************************************************
// Assembly         : CEPAberto
// Author           : Guilherme Branco Stracini
// Created          : 2018-08-15
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 25/03/2023
// ***********************************************************************
// <copyright file="CEPAbertoBaseRequest.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************

using GuiStracini.SDKBuilder;
using Newtonsoft.Json;

namespace CEPAberto.Transport
{
    /// <summary>
    /// All classes that performs a direct request to the CEP Aberto API must inherit from this class.
    /// </summary>
    public abstract class CEPAbertoBaseRequest : BaseRequest
    {
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>The token.</value>
        [JsonIgnore]
        public string Token { get; set; }
    }
}
