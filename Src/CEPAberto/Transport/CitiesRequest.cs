using GuiStracini.SDKBuilder.Routing;

namespace CEPAberto.Transport;

/// <summary>
/// The cities request class.
/// </summary>
/// <seealso cref="CEPAberto.Transport.CEPAbertoBaseRequest"/>
[EndpointRoute("cities?estado={StateInitials}")]
public sealed class CitiesRequest : CEPAbertoBaseRequest
{
    /// <summary>
    /// Gets or sets the state initials.
    /// </summary>
    /// <value>The state initials.</value>
    public string StateInitials { get; set; }
}
