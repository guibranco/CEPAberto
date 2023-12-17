using GuiStracini.SDKBuilder;
using GuiStracini.SDKBuilder.Routing;
using Newtonsoft.Json;

namespace CEPAberto.Transport;

/// <summary>
/// The address request class.
/// </summary>
/// <seealso cref="CEPAberto.Transport.CEPAbertoBaseRequest"/>
[EndpointRoute("address?estado={StateInitials}&cidade={City}")]
public sealed class AddressRequest : CEPAbertoBaseRequest
{
    /// <summary>
    /// Gets or sets the state initials.
    /// </summary>
    /// <value>The state initials.</value>
    public string StateInitials { get; set; }

    /// <summary>
    /// Gets or sets the city.
    /// </summary>
    /// <value>The city.</value>
    public string City { get; set; }

    /// <summary>
    /// Gets or sets the neighborhood.
    /// </summary>
    /// <value>The neighborhood.</value>
    [AdditionalRouteValue(ActionMethod.GET, true)]
    [JsonProperty("bairro")]
    public string Neighborhood { get; set; }

    /// <summary>
    /// Gets or sets the street.
    /// </summary>
    /// <value>The street.</value>
    [AdditionalRouteValue(ActionMethod.GET, true)]
    [JsonProperty("logradouro")]
    public string Street { get; set; }
}
