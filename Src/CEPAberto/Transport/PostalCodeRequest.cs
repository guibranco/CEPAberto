using GuiStracini.SDKBuilder.Routing;

namespace CEPAberto.Transport;

/// <summary>
/// The postal code request class.
/// </summary>
[EndpointRoute("cep?cep={PostalCode}")]
public sealed class PostalCodeRequest : CEPAbertoBaseRequest
{
    /// <summary>
    /// Gets or sets the postal code.
    /// </summary>
    /// <value>The postal code.</value>
    public string PostalCode { get; set; }
}
