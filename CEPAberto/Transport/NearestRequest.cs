namespace CEPAberto.Transport
{
    using Attributes;
    using System;

    /// <summary>
    /// The nearest request class.
    /// </summary>
    /// <seealso cref="CEPAberto.Transport.BaseRequest" />
    [RequestEndPoint("nearest?lat={Latitude}&lng={Longitude}")]
    public sealed class NearestRequest : BaseRequest
    {
        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>
        /// The latitude.
        /// </value>
        public String Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        public String Longitude { get; set; }

    }
}
