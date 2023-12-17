using Newtonsoft.Json;

namespace CEPAberto.ValueObject;

/// <summary>
/// The city entity of the postal code response
/// </summary>
public sealed class City
{
    /// <summary>
    /// Gets or sets the area code.
    /// </summary>
    /// <value>The area code.</value>
    [JsonProperty("ddd")]
    public int? AreaCode { get; set; }

    /// <summary>
    /// Gets or sets the fiscal code.
    /// </summary>
    /// <value>The fiscal code.</value>
    [JsonProperty("ibge")]
    public int? FiscalCode { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    [JsonProperty("nome")]
    public string Name { get; set; }
}
