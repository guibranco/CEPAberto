using GuiStracini.SDKBuilder.Routing;

namespace CEPAberto.Transport;

/// <summary>
/// The nearest request class.
/// </summary>
/// <seealso cref="CEPAberto.Transport.CEPAbertoBaseRequest"/>
[EndpointRoute("nearest?lat={Latitude}&lng={Longitude}")]
public sealed class NearestRequest : CEPAbertoBaseRequest
{
    /// <summary>
    /// Gets or sets the latitude.
    /// </summary>
    /// <value>The latitude.</value>
    public string Latitude { get; set; }

    /// <summary>
    /// Gets or sets the longitude.
    /// </summary>
    /// <value>The longitude.</value>
    public string Longitude { get; set; }
}
