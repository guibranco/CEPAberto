using GuiStracini.SDKBuilder;
using Newtonsoft.Json;

namespace CEPAberto.Transport;

/// <summary>
/// All classes that performs a direct request to the CEP Aberto API must inherit from this class.
/// </summary>
public abstract class CEPAbertoBaseRequest : IBaseRequest
{
    /// <summary>
    /// Gets or sets the token.
    /// </summary>
    /// <value>The token.</value>
    [JsonIgnore]
    public string Token { get; set; }
}
