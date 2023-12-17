using Newtonsoft.Json;

namespace CEPAberto.ValueObject;

/// <summary>
/// The state entity of the postal code response.
/// </summary>
public sealed class State
{
    /// <summary>
    /// Gets or sets the initials.
    /// </summary>
    /// <value>The initials.</value>
    [JsonProperty("sigla")]
    public string Initials { get; set; }
}
