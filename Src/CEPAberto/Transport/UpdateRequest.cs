using GuiStracini.SDKBuilder.Routing;
using Newtonsoft.Json;

namespace CEPAberto.Transport;

/// <summary>
/// Class UpdateRequest. This class cannot be inherited.
/// </summary>
[EndpointRoute("update")]
public sealed class UpdateRequest : CEPAbertoBaseRequest
{
    /// <summary>
    /// Gets or sets the postal codes.
    /// </summary>
    /// <value>The postal codes.</value>
    [JsonProperty("ceps")]
    public string PostalCodes { get; set; }
}
