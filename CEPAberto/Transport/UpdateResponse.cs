// ***********************************************************************
// Assembly         : CEPAberto
// Author           : Guilherme Branco Stracini
// Created          : 10/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 10/01/2023
// ***********************************************************************
// <copyright file="UpdateResponse.cs" company="Guilherme Branco Stracini">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CEPAberto.Transport
{
    /// <summary>
    /// Class UpdateResponse. This class cannot be inherited.
    /// Implements the <see cref="CEPAberto.Transport.BaseResponse" />
    /// </summary>
    /// <seealso cref="CEPAberto.Transport.BaseResponse" />
    public sealed class UpdateResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public string[] Content { get; set; }
    }
}
