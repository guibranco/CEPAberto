namespace CEPAberto.ValueObject
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// The state entity of the postal code response.
    /// </summary>
    public sealed class State
    {
        /// <summary>
        /// Gets or sets the initials.
        /// </summary>
        /// <value>
        /// The initials.
        /// </value>
        [JsonProperty("sigla")]
        public String Initials { get; set; }
    }
}
