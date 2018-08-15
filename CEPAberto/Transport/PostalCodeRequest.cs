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
