namespace CEPAberto.Transport
{
    using Attributes;
    using System;

    /// <summary>
    /// The address request class.
    /// </summary>
    /// <seealso cref="CEPAberto.Transport.BaseRequest" />
    [RequestEndPoint("address/?estado={StateInitials}&cidade={City}&bairro={Neighborhood}&logradouro={Street}")]
    public sealed class AddressRequest : BaseRequest
    {
        /// <summary>
        /// Gets or sets the state initials.
        /// </summary>
        /// <value>
        /// The state initials.
        /// </value>
        public String StateInitials { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public String City { get; set; }

        /// <summary>
        /// Gets or sets the neighborhood.
        /// </summary>
        /// <value>
        /// The neighborhood.
        /// </value>
        public String Neighborhood { get; set; }

        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        /// <value>
        /// The street.
        /// </value>
        public String Street { get; set; }
    }
}
