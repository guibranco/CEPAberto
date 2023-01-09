// ***********************************************************************
// Assembly         : CEPAberto
// Author           : Guilherme Branco Stracini
// Created          : 2018-08-15
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 01-10-2023
// ***********************************************************************
// <copyright file="ICEPAbertoClient.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CEPAberto
{
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
        /// <returns>PostalCodeData.</returns>
        PostalCodeData GetData(string postalCode);

        /// <summary>
        /// Gets the data asynchronous.
        /// </summary>
        /// <param name="postalCode">The postal code.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;PostalCodeData&gt;.</returns>
        Task<PostalCodeData> GetDataAsync(string postalCode, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <returns>PostalCodeData.</returns>
        PostalCodeData GetData(string latitude, string longitude);

        /// <summary>
        /// Gets the data asynchronous.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;PostalCodeData&gt;.</returns>
        Task<PostalCodeData> GetDataAsync(string latitude, string longitude, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="stateInitials">The state initials.</param>
        /// <param name="city">The city.</param>
        /// <param name="neighborhood">The neighborhood.</param>
        /// <param name="street">The street.</param>
        /// <returns>PostalCodeData.</returns>
        PostalCodeData GetData(string stateInitials, string city, string neighborhood, string street);

        /// <summary>
        /// Gets the data asynchronous.
        /// </summary>
        /// <param name="stateInitials">The state initials.</param>
        /// <param name="city">The city.</param>
        /// <param name="neighborhood">The neighborhood.</param>
        /// <param name="street">The street.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;PostalCodeData&gt;.</returns>
        Task<PostalCodeData> GetDataAsync(string stateInitials, string city, string neighborhood, string street, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the cities.
        /// </summary>
        /// <param name="stateInitials">The state initials.</param>
        /// <returns>CitiesData.</returns>
        CitiesData GetCities(string stateInitials);

        /// <summary>
        /// Gets the cities asynchronous.
        /// </summary>
        /// <param name="stateInitials">The state initials.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;CitiesData&gt;.</returns>
        Task<CitiesData> GetCitiesAsync(string stateInitials, CancellationToken cancellationToken);

        /// <summary>
        /// Updates the specified postal code list.
        /// </summary>
        /// <param name="postalCodeList">The postal code list.</param>
        /// <returns>UpdateData.</returns>
        UpdateData Update(string[] postalCodeList);

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="postalCodeList">The postal code list.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;UpdateData&gt;.</returns>
        Task<UpdateData> UpdateAsync(string[] postalCodeList, CancellationToken cancellationToken);
    }
}
