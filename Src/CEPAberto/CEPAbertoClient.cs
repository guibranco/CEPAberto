// *********************************************************************** Assembly : CEPAberto
// Author : Guilherme Branco Stracini Created : 2018-08-15
//
// Last Modified By : Guilherme Branco Stracini Last Modified On : 10/01/2023 ***********************************************************************
// <copyright file="CEPAbertoClient.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2023
// </copyright>
// <summary>
// </summary>
// ***********************************************************************
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CEPAberto.Transport;
using CEPAberto.Utils;
using CEPAberto.ValueObject;

namespace CEPAberto
{
    /// <summary>
    /// Class CEPAbertoClient. This class cannot be inherited. Implements the <see cref="CEPAberto.ICEPAbertoClient"/>
    /// </summary>
    /// <seealso cref="CEPAberto.ICEPAbertoClient"/>
    public sealed class CEPAbertoClient : ICEPAbertoClient
    {
        /// <summary>
        /// The service
        /// </summary>
        private readonly ServiceFactory _service;

        /// <summary>
        /// The token
        /// </summary>
        private readonly string _token;

        /// <summary>
        /// The configure await
        /// </summary>
        private readonly bool _configureAwait;

        /// <summary>
        /// Initializes a new instance of the <see cref="CEPAbertoClient"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="configureAwait">if set to <c>true</c> [configure await].</param>
        public CEPAbertoClient(string token, bool configureAwait = true)
        {
            _token = token;
            _configureAwait = configureAwait;
            _service = new ServiceFactory(_configureAwait);
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="postalCode">The postal code.</param>
        /// <returns>PostalCodeData.</returns>
        public PostalCodeData GetData(string postalCode)
        {
            return GetDataAsync(postalCode, CancellationToken.None).Result;
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <returns>PostalCodeData.</returns>
        public PostalCodeData GetData(string latitude, string longitude)
        {
            return GetDataAsync(latitude, longitude, CancellationToken.None).Result;
        }

        /// <summary>
        /// Gets the data asynchronous.
        /// </summary>
        /// <param name="postalCode">The postal code.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>PostalCodeData.</returns>
        public async Task<PostalCodeData> GetDataAsync(
            string postalCode,
            CancellationToken cancellationToken
        )
        {
            var data = new PostalCodeRequest { Token = _token, PostalCode = postalCode };

            var result = await _service
                .Get<PostalCodeData, PostalCodeRequest>(data, cancellationToken)
                .ConfigureAwait(_configureAwait);

            if (!string.IsNullOrEmpty(result.PostalCode))
            {
                result.Success = true;
            }

            return result;
        }

        /// <summary>
        /// Gets the data asynchronous.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>PostalCodeData.</returns>
        public async Task<PostalCodeData> GetDataAsync(
            string latitude,
            string longitude,
            CancellationToken cancellationToken
        )
        {
            var data = new NearestRequest
            {
                Token = _token,
                Latitude = latitude,
                Longitude = longitude
            };

            var result = await _service
                .Get<PostalCodeData, NearestRequest>(data, cancellationToken)
                .ConfigureAwait(_configureAwait);

            if (!string.IsNullOrEmpty(result.PostalCode))
            {
                result.Success = true;
            }

            return result;
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="stateInitials">The state initials.</param>
        /// <param name="city">The city.</param>
        /// <param name="neighborhood">The neighborhood.</param>
        /// <param name="street">The street.</param>
        /// <returns>PostalCodeData.</returns>
        public PostalCodeData GetData(
            string stateInitials,
            string city,
            string neighborhood,
            string street
        )
        {
            return GetDataAsync(
                stateInitials,
                city,
                neighborhood,
                street,
                CancellationToken.None
            ).Result;
        }

        /// <summary>
        /// Gets the data asynchronous.
        /// </summary>
        /// <param name="stateInitials">The state initials.</param>
        /// <param name="city">The city.</param>
        /// <param name="neighborhood">The neighborhood.</param>
        /// <param name="street">The street.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>PostalCodeData.</returns>
        public async Task<PostalCodeData> GetDataAsync(
            string stateInitials,
            string city,
            string neighborhood,
            string street,
            CancellationToken cancellationToken
        )
        {
            var data = new AddressRequest
            {
                Token = _token,
                StateInitials = stateInitials,
                City = city,
                Neighborhood = neighborhood,
                Street = street
            };

            var result = await _service
                .Get<PostalCodeData, AddressRequest>(data, cancellationToken)
                .ConfigureAwait(_configureAwait);

            if (!string.IsNullOrEmpty(result.PostalCode))
            {
                result.Success = true;
            }

            return result;
        }

        /// <summary>
        /// Gets the cities.
        /// </summary>
        /// <param name="stateInitials">The state initials.</param>
        /// <returns>CitiesData.</returns>
        public CitiesData GetCities(string stateInitials)
        {
            return GetCitiesAsync(stateInitials, CancellationToken.None).Result;
        }

        /// <summary>
        /// Gets the cities asynchronous.
        /// </summary>
        /// <param name="stateInitials">The state initials.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>CitiesData.</returns>
        public async Task<CitiesData> GetCitiesAsync(
            string stateInitials,
            CancellationToken cancellationToken
        )
        {
            var data = new CitiesRequest { Token = _token, StateInitials = stateInitials, };

            var results = await _service
                .Get<City[], CitiesRequest>(data, cancellationToken)
                .ConfigureAwait(_configureAwait);

            return new CitiesData
            {
                Cities = results,
                StateInitials = stateInitials,
                Success = results.Any()
            };
        }

        /// <summary>
        /// Updates the specified postal code list.
        /// </summary>
        /// <param name="postalCodeList">The postal code list.</param>
        /// <returns>UpdateData.</returns>
        public UpdateData Update(string[] postalCodeList)
        {
            return UpdateAsync(postalCodeList, CancellationToken.None).Result;
        }

        /// <summary>
        /// update as an asynchronous operation.
        /// </summary>
        /// <param name="postalCodeList">The postal code list.</param>
        /// <param name="cancellationToken">
        /// The cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>Task&lt;UpdateData&gt;.</returns>
        public async Task<UpdateData> UpdateAsync(
            string[] postalCodeList,
            CancellationToken cancellationToken
        )
        {
            var data = new UpdateRequest
            {
                Token = _token,
                PostalCodes = string.Join(",", postalCodeList)
            };

            var result = await _service
                .Post<UpdateResponse, UpdateRequest>(data, cancellationToken)
                .ConfigureAwait(_configureAwait);

            if (!string.IsNullOrWhiteSpace(result.Error))
            {
                return new UpdateData
                {
                    Success = false,
                    ErrorCode = result.Status,
                    ErrorMessage = result.Error
                };
            }

            return new UpdateData { Success = true, PostalCodeList = result.Content };
        }
    }
}
