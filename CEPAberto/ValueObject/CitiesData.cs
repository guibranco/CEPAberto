namespace CEPAberto.ValueObject
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// The cities data response class.
    /// </summary>
    public sealed class CitiesData
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Cities"/> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        [JsonIgnore]
        public Boolean Success { get; set; }

        /// <summary>
        /// Gets or sets the state initials.
        /// </summary>
        /// <value>
        /// The state initials.
        /// </value>
        [JsonIgnore]
        public String StateInitials { get; set; }

        /// <summary>
        /// Gets or sets the cities.
        /// </summary>
        /// <value>
        /// The cities.
        /// </value>
        public City[] Cities { get; set; }
    }
}
