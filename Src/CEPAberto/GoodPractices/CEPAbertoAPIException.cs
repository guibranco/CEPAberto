﻿using System;
using System.Runtime.Serialization;

namespace CEPAberto.GoodPractices;

/// <inheritdoc/>
/// <summary>
/// Throws when a exception occurs in the <see cref="T:CEPAberto.ServiceFactory"/><c>Execute</c> method.
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

    /// <inheritdoc/>
    /// <summary>
    /// Initializes a new instance of the <see cref="T:System.Exception"/> class with serialized data.
    /// </summary>
    /// <param name="info">
    /// The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized
    /// object data about the exception being thrown.
    /// </param>
    /// <param name="context">
    /// The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual
    /// information about the source or destination.
    /// </param>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="info"/> parameter is null.
    /// </exception>
    /// <exception cref="T:System.Runtime.Serialization.SerializationException">
    /// The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0).
    /// </exception>
    protected CEPAbertoApiException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
}
