namespace CEPAberto.Transport;

/// <summary>
/// Class UpdateResponse. This class cannot be inherited. Implements the <see cref="CEPAberto.Transport.BaseResponse"/>
/// </summary>
/// <seealso cref="CEPAberto.Transport.BaseResponse"/>
public sealed class UpdateResponse : BaseResponse
{
    /// <summary>
    /// Gets or sets the content.
    /// </summary>
    /// <value>The content.</value>
    public string[] Content { get; set; }
}
