// ***********************************************************************
// Assembly         : CEPAberto
// Author           : Guilherme Branco Stracini
// Created          : 2018-08-15
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 2018-08-15
// ***********************************************************************
// <copyright file="ICEPAbertoClient.cs" company="Guilherme Branco Stracini">
//     Copyright © 2018 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CEPAberto
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using ValueObject;

    /// <summary>
    /// The CEP Aberto client interface
    /// </summary>
    public interface ICEPAbertoClient
    {
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="postalCode">The postal code.</param>
        /// <returns></returns>
        PostalCodeData GetData(String postalCode);

        /// <summary>
        /// Gets the data asynchronous.
        /// </summary>
        /// <param name="postalCode">The postal code.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns></returns>
        Task<PostalCodeData> GetDataAsync(String postalCode, CancellationToken token);

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <returns></returns>
        PostalCodeData GetData(String latitude, String longitude);

        /// <summary>
        /// Gets the data asynchronous.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns></returns>
        Task<PostalCodeData> GetDataAsync(String latitude, String longitude, CancellationToken token);

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="stateInitials">The state initials.</param>
        /// <param name="city">The city.</param>
        /// <param name="neighborhood">The neighborhood.</param>
        /// <param name="street">The street.</param>
        /// <returns></returns>
        PostalCodeData GetData(String stateInitials, String city, String neighborhood, String street);

        /// <summary>
        /// Gets the data asynchronous.
        /// </summary>
        /// <param name="stateInitials">The state initials.</param>
        /// <param name="city">The city.</param>
        /// <param name="neighborhood">The neighborhood.</param>
        /// <param name="street">The street.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns></returns>
        Task<PostalCodeData> GetDataAsync(String stateInitials, String city, String neighborhood, String street, CancellationToken token);

        /// <summary>
        /// Gets the cities.
        /// </summary>
        /// <param name="stateInitials">The state initials.</param>
        /// <returns></returns>
        CitiesData GetCities(String stateInitials);

        /// <summary>
        /// Gets the cities asynchronous.
        /// </summary>
        /// <param name="stateInitials">The state initials.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns></returns>
        Task<CitiesData> GetCitiesAsync(String stateInitials, CancellationToken token);
    }
}
