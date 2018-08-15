namespace CEPAberto.Transport
{
    using Attributes;
    using System;

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
        public String StateInitials { get; set; }
    }
}
