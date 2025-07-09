using System;

namespace CEPAberto.GoodPractices;

/// <inheritdoc/>
/// <summary>
/// Throws when an exception occurs in the Service Factory <c>Execute</c> method.
/// </summary>
/// <seealso cref="T:System.Exception"/>
[Serializable]
public class CEPAbertoApiException : Exception
{
    /// <inheritdoc/>
    /// <summary>
    /// Initializes a new instance of the <see cref="T:System.Exception"/> class with a specified
    /// error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="endpoint">The endpoint of the request that throws an exception.</param>
    /// <param name="innerException">
    /// The exception that is the cause of the current exception, or a null reference (Nothing in
    /// Visual Basic) if no inner exception is specified.
    /// </param>
    public CEPAbertoApiException(string endpoint, Exception innerException)
        : base($"Unable to complete request to the {endpoint} endpoint", innerException) { }
}
