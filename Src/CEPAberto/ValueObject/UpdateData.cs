// ***********************************************************************
// Assembly         : CEPAberto
// Author           : Guilherme Branco Stracini
// Created          : 06-28-2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 10/01/2023
// ***********************************************************************
// <copyright file="UpdateData.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CEPAberto.ValueObject
{
    /// <summary>
    /// Class UpdateData.
    /// </summary>
    public class UpdateData
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="UpdateData" /> is success.
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        /// <value>The error code.</value>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the postal code list.
        /// </summary>
        /// <value>The postal code list.</value>
        public string[] PostalCodeList { get; set; }
    }
}
